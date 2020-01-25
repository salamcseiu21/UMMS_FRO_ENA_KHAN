using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL.Contracts.HR;
using UniversityManagementSystem.DatabaseContext.DatabaseContexts;
using UniversityManagementSystem.Models.EntityModels.HR;

namespace UniversityManagementSystem.Areas.Editor.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentManager _iDepartmentManager;

        public DepartmentsController(IDepartmentManager iDepartmentManager)
        {
            _iDepartmentManager = iDepartmentManager;
        }


        public ActionResult Index()
        {
            return View(_iDepartmentManager.GetAll().ToList());
        }


        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _iDepartmentManager.GetById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {


            if (ModelState.IsValid)
            {





                if (_iDepartmentManager.Add(department))
                {
                    return RedirectToAction("Index");
                }





            }

            return View(department);
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _iDepartmentManager.GetById(id);


            if (department == null)
            {


                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {




                _iDepartmentManager.Update(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }


        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _iDepartmentManager.GetById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Department department = _iDepartmentManager.GetById(id);
            _iDepartmentManager.Remove(department);

            return RedirectToAction("Index");
        }
    }
}
