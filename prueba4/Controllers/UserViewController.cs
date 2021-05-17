using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba4.Controllers
{
    public class UserViewController : Controller
    {
        // GET: UserView
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserView/Create
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

        // GET: UserView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserView/Edit/5
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

        // GET: UserView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserView/Delete/5
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

        prueba4.Models.dbwencoEntities db = new prueba4.Models.dbwencoEntities();

        [ValidateInput(false)]
        public ActionResult userViewPartial()
        {
            var model = db.Dk_user;
            return PartialView("~/Views/GridView/_userViewPartial.cshtml", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult userViewPartialAddNew(prueba4.Models.Dk_user item)
        {
            var model = db.Dk_user;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/GridView/_userViewPartial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult userViewPartialUpdate(prueba4.Models.Dk_user item)
        {
            var model = db.Dk_user;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/GridView/_userViewPartial.cshtml", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult userViewPartialDelete(System.Int32 id)
        {
            var model = db.Dk_user;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("~/Views/GridView/_userViewPartial.cshtml", model.ToList());
        }
    }
}
