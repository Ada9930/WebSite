using System;
using System.Collections.Generic;
using System.Linq;
namespace ClassWeb.Models.Student
{
    public class SearchListModel: StudentModel
    {
        #region - Definition -

        public List<ClassWeb.Repository.Entity.Student> studentList { get; set; } = new List<ClassWeb.Repository.Entity.Student>();
        #endregion

        #region - Method -
        public void GetSearchList()
        {
            using(ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                string birthday = "";
                if (!string.IsNullOrEmpty(Birthday.ToString("yyyy-MM-dd")) && Birthday.ToString("yyyy-MM-dd") != "0001-01-01")
                {
                    birthday = Birthday.ToString("yyyy-MM-dd");
                }
                studentList = DBEntity.Student.Where(o => !string.IsNullOrEmpty(No) ? o.Student_No == No : true &&
                                                          !string.IsNullOrEmpty(Name) ? o.Student_Name.Contains(Name) : true &&
                                                          !string.IsNullOrEmpty(birthday) ? o.Student_Birthday == Birthday : true &&
                                                          !string.IsNullOrEmpty(Email) ? o.Student_Email == Email : true).ToList();
            }
        }

        #endregion

    }
}