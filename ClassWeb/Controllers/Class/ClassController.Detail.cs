using ClassWeb.Models.Class;
using System.Web.Mvc;

namespace ClassWeb.Controllers
{
    public partial class ClassController
    {
        [HttpGet]
        public ActionResult Detail(string ActionMode, string No)
        {
            DetailModel model = new DetailModel();
            model.ActionMode = ActionMode;
            model.No = No;

            if (ActionMode != "Add")
            {
                model.GetDetail();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Detail(DetailModel model)
        {
            switch (model.ActionMode)
            {
                case "Add":
                    model.InsertClass();
                    break;
                case "Update":
                    model.UpdateClass();
                    break;
                case "Delete":
                    model.DeleteClass();
                    break;
            }

            return RedirectToAction("SearchList");
        }
    }
}