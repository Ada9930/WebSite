using System;
using System.Linq;

namespace ClassWeb.Models.Class
{
    public class DetailModel:ClassModel
    {
        //動作
        public string ActionMode { get; set; }
        public string ErrMsg { get; set; }

        #region - Method -
        //取得詳細資料
        public bool GetDetail()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {

                ClassWeb.Repository.Entity.Class classData = DBEntity.Class.Where(o => o.Class_No == No).FirstOrDefault();

                if (classData != null)
                {
                    Name = classData.Class_Name;
                    Credit = classData.Class_Credit;
                    Place = classData.Class_Place;
                    Teacher = classData.Class_Teacher;
                }
                else
                {
                    ErrMsg = string.Format("課程:{0} 查無課程資料, 請檢查", No);
                    return false;
                }
                return true;
            }


        }

        //新增資料
        public void InsertClass()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                ClassWeb.Repository.Entity.Class classData = new Repository.Entity.Class();
                classData.Class_No = GetNewClassNo();
                classData.Class_Name = Name;
                classData.Class_Credit = Credit;
                classData.Class_Place = Place;
                classData.Class_Teacher = Teacher;
                DBEntity.Class.Add(classData);
                DBEntity.SaveChanges();
            }
        }

        public void UpdateClass()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                ClassWeb.Repository.Entity.Class classData = DBEntity.Class.Where(o => o.Class_No == No).FirstOrDefault();

                classData.Class_Name = Name;
                classData.Class_Credit = Credit;
                classData.Class_Place = Place;
                classData.Class_Teacher = Teacher;

                DBEntity.SaveChanges();
            }
        }

        public void DeleteClass()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                ClassWeb.Repository.Entity.Class classData = DBEntity.Class.Where(o => o.Class_No == No).FirstOrDefault();

                DBEntity.Class.Remove(classData);

                DBEntity.SaveChanges();
            }
        }

        public string GetNewClassNo()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                ClassWeb.Repository.Entity.Class lastData = DBEntity.Class.OrderByDescending(o => o.Class_No).FirstOrDefault();
                if(lastData != null)
                {
                    return string.Concat("C", string.Format("{0:000}", (Convert.ToInt32(lastData.Class_No.Substring(1, 3)) + 1)));
                }
                else
                {
                    return "C001";
                }

            }
        }

        #endregion
    }
}