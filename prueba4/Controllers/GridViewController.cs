using DevExpress.Web.Mvc;
using prueba4.Model;
using System;
using System.Linq;
using System.Web.Mvc;

namespace prueba4.Controllers {
    public class GridViewController : BaseController {
        // GET: GridView
        public ActionResult Index()
        {
            return View(GridViewHelper.GetIssues());
        }
        public ActionResult GridViewDetailsPage(long id) {
            ViewBag.ShowBackButton = true;
            return View(DataProvider.GetIssues().Find(i => i.Id == id));
        }
        public ActionResult GridViewPartial() {
            return PartialView("GridViewPartial", GridViewHelper.GetIssues());
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction) {
            if(customAction == "delete")
                SafeExecute(() => PerformDelete());
            return GridViewPartial();
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewAddNewPartial(Issue issue) {
            return UpdateModelWithDataValidation(issue, GridViewHelper.AddNewRecord);
        }
        [ValidateAntiForgeryToken]
        public ActionResult GridViewUpdatePartial(Issue issue) {
            return UpdateModelWithDataValidation(issue, GridViewHelper.UpdateRecord);
        }

        private ActionResult UpdateModelWithDataValidation(Issue issue, Action<Issue> updateMethod) {
            if(ModelState.IsValid)
                SafeExecute(() => updateMethod(issue));
            else
                ViewBag.GeneralError = "Please, correct all errors.";
            return GridViewPartial();
        }
        private void PerformDelete() {
            if(!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
                GridViewHelper.DeleteRecords(Request.Params["SelectedRows"]);
        }

        prueba4.Models.dbwencoEntities db = new prueba4.Models.dbwencoEntities();

        [ValidateInput(false)]
        public ActionResult DataViewPartial()
        {
            var model = db.Dk_user;
            return PartialView("_DataViewPartial", model.ToList());
        }
    }
}