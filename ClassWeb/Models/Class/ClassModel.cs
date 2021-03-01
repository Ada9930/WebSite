namespace ClassWeb.Models.Class
{
    public class ClassModel
    {
        #region - Defintion -
        //課程編號
        public string No { get; set; }
        //課程名稱
        public string Name { get; set; }
        //學分數
        public int Credit { get; set; }
        //課程地點
        public string Place { get; set; }
        //教師名稱
        public string Teacher { get; set; }
        #endregion
    }
}