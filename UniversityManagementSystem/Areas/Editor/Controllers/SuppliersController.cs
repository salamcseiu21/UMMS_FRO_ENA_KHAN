using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL.Contracts.Company;
using UniversityManagementSystem.DatabaseContext.DatabaseContexts;
using UniversityManagementSystem.Models.EntityModels.Company;

namespace UniversityManagementSystem.Areas.Editor.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierManager _iSupplierManager;

        public SuppliersController(ISupplierManager iSupplierManager)
        {
            _iSupplierManager = iSupplierManager;
        }


        public ActionResult Index()
        {
            return View(_iSupplierManager.GetAll().ToList());
        }


        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _iSupplierManager.GetById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {


            if (ModelState.IsValid)
            {





                if (_iSupplierManager.Add(supplier))
                {
                    return RedirectToAction("Index");
                }





            }

            return View(supplier);
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _iSupplierManager.GetById(id);


            if (supplier == null)
            {


                return HttpNotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {




                _iSupplierManager.Update(supplier);
                return RedirectToAction("Index");
            }
            return View(supplier);
        }


        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _iSupplierManager.GetById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Supplier supplier = _iSupplierManager.GetById(id);
            _iSupplierManager.Remove(supplier);

            return RedirectToAction("Index");
        }
    }
}
