using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL.Contracts.Invetories;
using UniversityManagementSystem.DatabaseContext.DatabaseContexts;
using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.Areas.Editor.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly IProductCategoryManager _iProductCategoryManager;

        public ProductCategoriesController(IProductCategoryManager iProductCategoryManager)
        {
            _iProductCategoryManager = iProductCategoryManager;
        }


        public ActionResult Index()
        {
            return View(_iProductCategoryManager.GetAll().ToList());
        }


        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = _iProductCategoryManager.GetById(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategory productCategory)
        {


            if (ModelState.IsValid)
            {





                if (_iProductCategoryManager.Add(productCategory))
                {
                    return RedirectToAction("Index");
                }





            }

            return View(productCategory);
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = _iProductCategoryManager.GetById(id);


            if (productCategory == null)
            {


                return HttpNotFound();
            }
            return View(productCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {




                _iProductCategoryManager.Update(productCategory);
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }


        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = _iProductCategoryManager.GetById(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProductCategory productCategory = _iProductCategoryManager.GetById(id);
            _iProductCategoryManager.Remove(productCategory);

            return RedirectToAction("Index");
        }
    }
}
