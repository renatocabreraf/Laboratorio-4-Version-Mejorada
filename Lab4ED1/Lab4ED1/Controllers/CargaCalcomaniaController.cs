using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using Lab4ED1.DB;
using Lab4ED1.Models;

namespace Lab4ED1.Controllers
{
    public class CargaCalcomaniaController : Controller
    {
        JsonConnection db = JsonConnection.getInstance;

        // GET: CargaCalcomania
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Calcomania cg = db.listaCalcomaniasCargadas.Find(x => x.numero == id);

            if (cg == null)
            {
                return HttpNotFound();
            }

            return View(cg);
        }
       
        
        public ActionResult Lista()
        {
            return View(db.listaCalcomaniasCargadas.ToList());
        }


      

        // GET: CargaPartido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CargaPartido/Create
        public ActionResult Create()
        {
            return View();
        }

       

        // POST: CargaPartido/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase postedFile)
        {

           



            if (postedFile != null)
            {


                string filepath = string.Empty;

                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filepath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filepath);

                string csvData = System.IO.File.ReadAllText(filepath);

               
                db.listaCalcomaniasEstadoCargadas.Clear();
                Lista<Calcomania> listado = new Lista<Calcomania>();
                try
                {
                    JObject json = JObject.Parse(csvData);
                    
                    foreach (JProperty property in json.Properties())
                    {

                        string x = property.Value.ToString();
                        Calcomania y = JsonConvert.DeserializeObject<Calcomania>(x);
                        
                        db.CargaAlbum.Add(y, y.listado);


                    }
                   
                    

                    ViewBag.Message = "Cargado Exitosamente";


                }
                catch (Exception)
                {
                    ViewBag.Message = "Dato erroneo.";
                }

            }

            return View();
        }
        [HttpPost]
        public ActionResult Create1(HttpPostedFileBase postedFile)
        {





            if (postedFile != null)
            {


                string filepath = string.Empty;

                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filepath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filepath);

                string csvData = System.IO.File.ReadAllText(filepath);

                
                db.listaCalcomaniasEstadoCargadas.Clear();
                Lista<Calcomania> listado = new Lista<Calcomania>();
                try
                {
                    JObject json = JObject.Parse(csvData);

                    foreach (JProperty property in json.Properties())
                    {

                        string x = property.Value.ToString();
                        Calcomania y = JsonConvert.DeserializeObject<Calcomania>(x);

                        db.CargaCalcomanias.Add(y, y.falta);

                        


                    }



                    ViewBag.Message = "Cargado Exitosamente";


                }
                catch (Exception)
                {
                    ViewBag.Message = "Dato erroneo.";
                }

            }

            return View();
        }
       

        
        // GET: CargaPartido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CargaPartido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CargaPartido/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Calcomania cg = db.listaCalcomaniasCargadas.Find(x => x.numero == id);

            if (cg == null)
            {
                return HttpNotFound();
            }

            return View(cg);
        }

        // POST: CargaPartido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                Calcomania cg = db.listaCalcomaniasCargadas.Find(x => x.numero == id);
                db.CargaCalcomanias.Remove(cg);
               
                

                

                

                return RedirectToAction("IndexInNoPartido");
            }
            catch
            {
                return View();
            }
        }

        


   
    }
}
