using ClassWeb.Models.TakeClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassWeb.Controllers
{
    public class TakeClassController : Controller
    {
        [HttpGet]
        public ActionResult TakeClassList(string ActionMode, string StudentNo)
        {
            TakeClassListModel model = new TakeClassListModel();
            model.ActionMode = ActionMode;
            model.StudentNo = StudentNo;
            return TakeClassList(model);
        }
        [HttpPost]
        public ActionResult TakeClassList(TakeClassListModel model)
        {
            switch(model.ActionMode)
            {
                case "Add": //修改等同新增, 為避免資料異常, 多筆資料時, 先刪除後新增資料
                    model.AddTakeClassList();
                    break;
                case "Delete":
                    model.DeleteTakeClassList();
                    break;
                
            }
            model.GetClassList();
            model.GetStudentList();
            model.GetTakeClassList();

            return View(model);
        }
    }
}