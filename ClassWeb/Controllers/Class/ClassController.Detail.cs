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
                if (!model.GetDetail())
                {
                    TempData["ResultMessage"] = model.ErrMsg;
                    return RedirectToAction("SearchList");
                }

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Detail(DetailModel model)
        {
            if (model.ActionMode != "Delete" && this.ModelState.IsValid) //如果資料驗證成功
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
            else
            {
                //失敗訊息
                ViewBag.ResultMessage = "資料有誤，請檢查";
                return View(model);
            }
                

            
        }
    }
}