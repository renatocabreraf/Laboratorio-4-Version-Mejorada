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
        public ActionResult Buscar()
        {
            return View();
        }
        // GET: Calcomania/Buscar1
        public ActionResult Buscar1()
        {
            return View();
        }
        public ActionResult Lista()
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
        public ActionResult Buscar(FormCollection collection)
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
        public ActionResult Buscar1(FormCollection collection)
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
        public ActionResult Lista(FormCollection collection)
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
