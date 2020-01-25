using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL.Contracts.Company;
using UniversityManagementSystem.BLL.Contracts.Invetories;
using UniversityManagementSystem.DatabaseContext.DatabaseContexts;
using UniversityManagementSystem.Models.EntityModels.Company;
using UniversityManagementSystem.Models.EntityModels.Invetories;

namespace UniversityManagementSystem.Areas.Editor.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductDetailsManager _iProductDetailsManager;
        private readonly IProductManager _iProductManager;
        public ProductDetailsController(IProductDetailsManager iProductDetailsManager, IProductManager iProductManager)
        {
            _iProductDetailsManager = iProductDetailsManager;
            _iProductManager = iProductManager;
        }


        public ActionResult Index()
        {
            return View(_iProductDetailsManager.GetAll().ToList());
        }


        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetails productDetails = _iProductDetailsManager.GetById(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            return View(productDetails);
        }

    
        public ActionResult Create()
        {
            ViewData["ProductId"]   = new SelectList(_iProductManager.GetAll(), "Id", "Name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductDetails productDetails)
        {
          
                if (ModelState.IsValid)
                {
                    

                    _iProductDetailsManager.Add(productDetails);
                    return RedirectToAction("Index");
                }
            ViewData["ProductId"] = new SelectList(_iProductManager.GetAll(), "Id", "Name");
                return View(productDetails);
            
        }

      
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetails productDetails = _iProductDetailsManager.GetById(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            ViewData["ProductId"] = new SelectList(_iProductManager.GetAll(), "Id", "Name");
            return View(productDetails);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductDetails productDetails)
        {
            if (ModelState.IsValid)
            {
               


                _iProductDetailsManager.Update(productDetails);
                return RedirectToAction("Index");
            }
            ViewData["ProductId"] = new SelectList(_iProductManager.GetAll(), "Id", "Name");
            return View(productDetails);
        }
        
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetails productDetails = _iProductDetailsManager.GetById(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProductDetails productDetails = _iProductDetailsManager.GetById(id);
            _iProductDetailsManager.Remove(productDetails);

            return RedirectToAction("Index");
        }
    }
}
