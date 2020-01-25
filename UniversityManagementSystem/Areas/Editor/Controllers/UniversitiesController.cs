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
    public class UniversitiesController : Controller
    {
        private readonly IUniversityManager _iUniversityManager;
        public UniversitiesController(IUniversityManager iUniversityManager)
        {
            _iUniversityManager = iUniversityManager;
        }


        public ActionResult Index()
        {
            return View(_iUniversityManager.GetAll().ToList());
        }


        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = _iUniversityManager.GetById(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(University university)
        {


            if (ModelState.IsValid)
            {





                if (_iUniversityManager.Add(university))
                {
                    return RedirectToAction("Index");
                }





            }

            return View(university);
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = _iUniversityManager.GetById(id);


            if (university == null)
            {


                return HttpNotFound();
            }
            return View(university);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(University university)
        {
            if (ModelState.IsValid)
            {




                _iUniversityManager.Update(university);
                return RedirectToAction("Index");
            }
            return View(university);
        }


        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = _iUniversityManager.GetById(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            University university = _iUniversityManager.GetById(id);
            _iUniversityManager.Remove(university);

            return RedirectToAction("Index");
        }
    }
}
