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
                case "Add":
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