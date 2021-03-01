using System;
using System.ComponentModel.DataAnnotations;

namespace ClassWeb.Models.Student
{
    public class StudentModel
    {
        #region - Defintion -
        //學生編號
        public string No { get; set; }
        //學生姓名
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "姓名 至多20碼")]
        [Display(Name = "姓名")]
        public string Name { get; set; }
        //生日
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }
        //Email
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        #endregion
    }
}