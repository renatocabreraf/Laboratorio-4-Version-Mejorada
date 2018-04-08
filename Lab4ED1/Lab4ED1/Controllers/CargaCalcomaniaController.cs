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

        public ActionResult Buscar1()
        {
            return View(db.listaCalcomaniaColeccionada.ToList());
        }
       
        
        public ActionResult Listado()
        {
            return View(db.listaCalcomaniaFaltantes.ToList());
        }

        public ActionResult Buscar(int id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Calcomania cg = db.listaCalcomaniaColeccionada.Find(x => x.numero == id);

            if (cg == null)
            {
                return HttpNotFound();
            }

            return View(cg);
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
        public ActionResult Create1()
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

               
                db.listaCalcomaniasCargadas.Clear();
                Lista<Calcomania> listado = new Lista<Calcomania>();
                try
                {
                    JObject json = JObject.Parse(csvData);
                    
                    foreach (JProperty property in json.Properties())
                    {
                        
                        string x = property.Value.ToString();
                        Lista<int> y = JsonConvert.DeserializeObject<Lista<int>>(x);
                        db.DiccionarioListados.Add(y.nombre, y);
                    }
                    for (int i = 0; i < db.DiccionarioListados.Values.Count; i++)
                    {

                        for (int j = 0; j < db.DiccionarioListados.Values.ElementAt(i).coleccionadas.Count; j++)
                        {
                            Calcomania nuevaCalcomania = new Calcomania();
                            nuevaCalcomania.nombre = db.DiccionarioListados.Values.ElementAt(i).nombre;
                            nuevaCalcomania.numero = db.DiccionarioListados.Values.ElementAt(i).coleccionadas.ElementAt(j);
                            db.listaCalcomaniaColeccionada.Add(nuevaCalcomania);
                            db.listaCalcomaniasCargadas.Add(nuevaCalcomania);
                        }
                        for (int j = 0; j < db.DiccionarioListados.Values.ElementAt(i).cambios.Count; j++)
                        {
                            Calcomania nuevaCalcomania = new Calcomania();
                            nuevaCalcomania.nombre = db.DiccionarioListados.Values.ElementAt(i).nombre;
                            nuevaCalcomania.numero = db.DiccionarioListados.Values.ElementAt(i).cambios.ElementAt(j);
                            db.listaCalcomaniaCambios.Add(nuevaCalcomania);
                            db.listaCalcomaniasCargadas.Add(nuevaCalcomania);
                        }
                        for (int j = 0; j < db.DiccionarioListados.Values.ElementAt(i).faltantes.Count; j++)
                        {
                            Calcomania nuevaCalcomania = new Calcomania();
                            nuevaCalcomania.nombre = db.DiccionarioListados.Values.ElementAt(i).nombre;
                            nuevaCalcomania.numero = db.DiccionarioListados.Values.ElementAt(i).faltantes.ElementAt(j);
                            nuevaCalcomania.falta = true;
                            db.listaCalcomaniaFaltantes.Add(nuevaCalcomania);
                            db.listaCalcomaniasCargadas.Add(nuevaCalcomania);
                        }
                    }


                    foreach (Calcomania item in db.listaCalcomaniasCargadas)
                    {
                        db.DiccionarioFaltantes.Add(item, item.falta);
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

                
                db.listaCalcomaniasCargadas.Clear();
               
                try
                {
                    JObject json = JObject.Parse(csvData);

                    foreach (JProperty property in json.Properties())
                    {
                        Lista<int> listado = new Lista<int>();
                        string x = property.Value.ToString();
                        Calcomania y = JsonConvert.DeserializeObject<Calcomania>(x);

                        db.DiccionarioFaltantes.Add(y, y.falta);
                        db.listaCalcomaniasCargadas.Add(y);
                        if (y.falta == true)
                        {
                            listado.faltantes.Add(y.numero);
                            db.listaCalcomaniaFaltantes.Add(y);
                        }
                        else
                        {
                            
                            if (listado.coleccionadas.Contains(y.numero))
                            {
                                listado.cambios.Add(y.numero);
                                db.listaCalcomaniaCambios.Add(y);
                            }
                            else
                            {
                                listado.coleccionadas.Add(y.numero);
                                db.listaCalcomaniaColeccionada.Add(y);
                            }
                            
                        }
                        db.DiccionarioListados.Add(y.nombre, listado);
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
        public ActionResult Edit([Bind(Include = "numero,nombre,falta")] Calcomania calcomania)
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

            Calcomania cg = db.listaCalcomaniaColeccionada.Find(x => x.numero == id);

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

                Calcomania cg = db.listaCalcomaniaColeccionada.Find(x => x.numero == id);
                db.DiccionarioFaltantes.Remove(cg);
                db.DiccionarioListados.Remove(cg.nombre);








                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        


   
    }
}
