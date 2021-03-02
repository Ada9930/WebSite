using System.ComponentModel.DataAnnotations;

namespace ClassWeb.Models.Class
{
    public class ClassModel
    {
        #region - Defintion -
        //課程編號
        public string No { get; set; }
        //課程名稱
        [Required]
        [StringLength(20)]
        [Display(Name = "課名")]
        public string Name { get; set; }
        //學分數
        [Range(1, 255)]
        [Display(Name="學分數")]
        public int Credit { get; set; }
        //上課地點
        [StringLength(20)]
        [Display(Name = "上課地點")]
        public string Place { get; set; }
        //講師姓名
        [StringLength(20)]
        [Display(Name = "講師姓名")]
        public string Teacher { get; set; }
        #endregion
    }
}