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
    public class ProductsController : Controller
    {
      
      
            private readonly IProductManager _iProductManager;
            private readonly IProductCategoryManager _iProductCategoryManager;
            
            public ProductsController(IProductManager iProductManager,
                IProductCategoryManager iProductCategoryManager
                
                )
            {
                _iProductManager = iProductManager;
                _iProductCategoryManager = iProductCategoryManager;
               
            }
      
        public ActionResult Index()
        {
            return View(_iProductManager.GetAll().ToList());
        }

      
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product productDetails = _iProductManager.GetById(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            return View(productDetails);
        }

       
        public ActionResult Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(_iProductCategoryManager.GetAll(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    product.ProductSerialNo = "P0000" + (_iProductManager.LastId() + 1);


                    if (_iProductManager.Add(product))
                    {
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
            catch (Exception e)
            {

                ViewBag.ProductExistMessage = e.Message;
            }

        }
        ViewData["ProductCategoryId"] = new SelectList(_iProductCategoryManager.GetAll(), "Id", "Name");
            return View(product);

        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product productDetails = _iProductManager.GetById(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(_iProductCategoryManager.GetAll(), "Id", "Name");
            return View(productDetails);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                // Product productToUpdate = _iProductManager.GetById(product.Id);
              //  product.ProductSerialNo = productToUpdate.ProductSerialNo;



                _iProductManager.Update(product);
                return RedirectToAction("Index");
            }
            ViewData["ProductCategoryId"] = new SelectList(_iProductCategoryManager.GetAll(), "Id", "Name");
            return View(product);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _iProductManager.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = _iProductManager.GetById(id);
            _iProductManager.Remove(product);

            return RedirectToAction("Index");
        }
    }
    }
