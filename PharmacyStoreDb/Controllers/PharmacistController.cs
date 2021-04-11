using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmacyStoreDb.Controllers
{
    public class PharmacistController : Controller
    {
        // GET: Pharmacist
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pharmacist/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pharmacist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pharmacist/Create
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

        // GET: Pharmacist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pharmacist/Edit/5
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

        // GET: Pharmacist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pharmacist/Delete/5
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
