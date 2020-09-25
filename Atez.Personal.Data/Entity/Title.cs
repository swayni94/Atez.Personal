namespace Atez.Personal.Data.Entity
{
    public class Title : BaseEntity
    {
        public string titlename { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public int departmentid { get; set; }
    }
}
