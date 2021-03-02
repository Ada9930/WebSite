using ClassWeb.Models.Class;
using System.Web.Mvc;

namespace ClassWeb.Controllers
{
    public partial class ClassController : Controller
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
            //取得查詢結果
            model.GetSearchList();
            ViewBag.ResultMessage = TempData["ResultMessage"];
            return View(model);
        }
    }
}