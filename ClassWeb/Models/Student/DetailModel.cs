using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassWeb.Models.Student
{
    public class DetailModel: StudentModel
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

                ClassWeb.Repository.Entity.Student student = DBEntity.Student.Where(o => o.Student_No == No).FirstOrDefault();

                if(student != null)
                {
                    Name = student.Student_Name;
                    Birthday = student.Student_Birthday;//.ToString("yyyy-MM-dd");
                    Email = student.Student_Email;
                }
                else
                {
                    ErrMsg = string.Format("學號:{0} 查無學生資料, 請檢查", No);
                    return false;
                }
                return true;
            }
            

        }

        //新增資料
        public void InsertStudent()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                ClassWeb.Repository.Entity.Student student = new Repository.Entity.Student();
                student.Student_No = GetNewStudentNo();
                student.Student_Name = Name;
                student.Student_Birthday = Convert.ToDateTime(Birthday);
                student.Student_Email = Email;
                DBEntity.Student.Add(student);
                DBEntity.SaveChanges();
            }
        }

        public void UpdateStudent()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                ClassWeb.Repository.Entity.Student student = DBEntity.Student.Where(o => o.Student_No == No).FirstOrDefault();

                student.Student_Name = Name;
                student.Student_Birthday = Convert.ToDateTime(Birthday);
                student.Student_Email = Email;
                
                DBEntity.SaveChanges();
            }
        }

        public void DeleteStudent()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                ClassWeb.Repository.Entity.Student student = DBEntity.Student.Where(o => o.Student_No == No).FirstOrDefault();

                DBEntity.Student.Remove(student);

                //一併刪除該學生修課紀錄避免資料關聯異常
                List<ClassWeb.Repository.Entity.TakeClass> takeClass = DBEntity.TakeClass.Where(o => o.TakeClass_Student == No).ToList();

                DBEntity.TakeClass.RemoveRange(takeClass);

                DBEntity.SaveChanges();
            }
        }

        public string GetNewStudentNo()
        {
            using (ClassWeb.Repository.Entity.SchoolEntities DBEntity = new Repository.Entity.SchoolEntities())
            {
                ClassWeb.Repository.Entity.Student lastData = DBEntity.Student.OrderByDescending(o => o.Student_No).FirstOrDefault();
                if (lastData != null)
                {
                    return string.Concat("S", string.Format("{0:0000}", (Convert.ToInt32(lastData.Student_No.Substring(1, 4)) + 1)));
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