using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Lab4ED1.DB;
using Lab4ED1.Models;

namespace Lab4ED1.Controllers
{
    public class CalcomaniaController : Controller
    {
        DefaultConnection db = DefaultConnection.getInstance;
        
        // GET: Calcomania
        public ActionResult Index()
        {
            return View(db.listaCalcomania.ToList());
        }

        // GET: Calcomania/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Calcomania/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: Calcomania/Buscar
        public ActionResult Buscar(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Calcomania cg = db.listaCalcomania.Find(x => x.numero == id);

            if (cg == null)
            {
                return HttpNotFound();
            }

            return View(cg);
        }

        // GET: Calcomania/Buscar1
        
        public ActionResult Listado()
        {
            return View();
        }

        // POST: Calcomania/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        [HttpPost]
        public ActionResult Listado(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Calcomania/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calcomania/Edit/5
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

        // GET: Calcomania/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Calcomania/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
