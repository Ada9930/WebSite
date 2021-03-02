using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ClassWeb.Models.TakeClass
{
    public class TakeClassListModel
    {
        public string ActionMode { get; set; }
        public string StudentNo { get; set; }
        public List<ClassItem> ClassNoList { get; set; } = new List<ClassItem>();
        public List<DataItem> dataItemList = new List<DataItem>();
        public List<SelectListItem> StudentSelectList = new List<SelectListItem>();

        public class ClassItem
        {
            public string ClassNo { get; set; }
            public string ClassName { get; set; }
            public bool IsCheck { get; set; }
        }
        
        public class DataItem
        {
            public string Student { get; set; }
            public List<string> Class { get; set; }
        }

        //取得課程選取清單
        public void GetClassList()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                List<ClassWeb.Repository.Entity.TakeClass> takeClassList = new List<Repository.Entity.TakeClass>();
                
                //當為修改時,將資料帶出
                if(ActionMode == "Update")
                {
                    takeClassList = DBEntity.TakeClass.Where(o => o.TakeClass_Student == StudentNo).ToList();
                }

                ClassNoList = new List<ClassItem>();
                foreach(ClassWeb.Repository.Entity.Class classData in DBEntity.Class.ToList())
                {
                    ClassNoList.Add(new ClassItem()
                    {
                        ClassNo = classData.Class_No,
                        ClassName = classData.Class_Name,
                        IsCheck = takeClassList.Count > 0? takeClassList.Exists(o => o.TakeClass_Class == classData.Class_No) : false
                    });
                }

            }
        }

        //取得學生資料 並塞入下拉清單
        public void GetStudentList()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                List < ClassWeb.Repository.Entity.Student> studnetList = DBEntity.Student.ToList();

                StudentSelectList.Add(new SelectListItem { Value = string.Empty, Text = string.Empty });
                foreach (ClassWeb.Repository.Entity.Student student in studnetList)
                {
                    StudentSelectList.Add(new SelectListItem() { Value = student.Student_No, Text = string.Concat(student.Student_No, " ",student.Student_Name) });

                }
            }
        }

        //將修課資料塞入顯示清單
        public void GetTakeClassList()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                dataItemList = DBEntity.TakeClass.Join(DBEntity.Class, t => t.TakeClass_Class, c => c.Class_No, (t, c) => new
                {
                    StudenNo = t.TakeClass_Student,
                    ClassNo = t.TakeClass_Class,
                    ClassName = c.Class_Name
                }).GroupBy(o => o.StudenNo)
                .Select(o => new DataItem { Student = o.Key, Class = o.Select(g => g.ClassName).ToList()}).ToList();
            }
        }

        public void AddTakeClassList()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                List<ClassWeb.Repository.Entity.TakeClass> takeClassList = DBEntity.TakeClass.Where(o => o.TakeClass_Student == StudentNo).ToList();
                DBEntity.TakeClass.RemoveRange(takeClassList);

                foreach (var ClassIsChk in ClassNoList.Where(o => o.IsCheck))
                {
                    ClassWeb.Repository.Entity.TakeClass takeClass = new ClassWeb.Repository.Entity.TakeClass();

                    takeClass.TakeClass_Student = StudentNo;
                    takeClass.TakeClass_Class = ClassIsChk.ClassNo;
                    DBEntity.TakeClass.Add(takeClass);
                }
                DBEntity.SaveChanges();
                StudentNo = string.Empty;
                ClassNoList = new List<ClassItem>();
            }
        }

        public void DeleteTakeClassList()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                List<ClassWeb.Repository.Entity.TakeClass> takeClassList = DBEntity.TakeClass.Where(o => o.TakeClass_Student == StudentNo).ToList();
                DBEntity.TakeClass.RemoveRange(takeClassList);

                DBEntity.SaveChanges();
            }
        }
    }
}