using ClassWeb.Models.Student;
using System.Web.Mvc;

namespace ClassWeb.Controllers.Student
{
    public partial class StudentController : Controller
    {
        [HttpGet]
        public ActionResult SearchList()
        {
            SearchListModel model = new SearchListModel();
            return SearchList(model);
        }
        [HttpPost]
        public ActionResult SearchList(SearchListModel model)
        {
            //取得查詢資料
            model.GetSearchList();
            ViewBag.ResultMessage = TempData["ResultMessage"];
            return View(model);
        }
    }
}