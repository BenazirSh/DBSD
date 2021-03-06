using PharmacyStoreDb.DAL;
using PharmacyStoreDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmacyStoreDb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            var repo = new ProductRepository();
            try
            {
                repo.Insert(product);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var repo = new ProductRepository();
            var emp = repo.GetById(id);
            return View(emp);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product t)
        {
            var repo = new ProductRepository();
            try
            {
                repo.Update(t);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
