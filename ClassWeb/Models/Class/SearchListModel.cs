using System.Collections.Generic;
using System.Linq;
namespace ClassWeb.Models.Class
{
    public class SearchListModel: ClassModel
    {
        #region - Definition -

        public List<ClassWeb.Repository.Entity.Class> classList { get; set; } = new List<ClassWeb.Repository.Entity.Class>();
        #endregion

        #region - Method -
        //取得查詢資料
        public void GetSearchList()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {

                classList = DBEntity.Class.Where(o => !string.IsNullOrEmpty(No) ? o.Class_No == No : true &&
                                                      !string.IsNullOrEmpty(Name) ? o.Class_Name.Contains(Name) : true &&
                                                      !string.IsNullOrEmpty(Credit.ToString()) && Credit != 0 ? o.Class_Credit == Credit : true &&
                                                      !string.IsNullOrEmpty(Place) ? o.Class_Place.Contains(Place) : true &&
                                                      !string.IsNullOrEmpty(Teacher)? o.Class_Teacher.Contains(Teacher) : true).ToList();
            }
        }

        #endregion
    }
}