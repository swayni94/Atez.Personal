namespace Atez.Personal.Data.Entity
{
    public class Department : BaseEntity
    {
        public string departmenname { get; set; }
        public int managerid { get; set; }
        public int locationid { get; set; }
    }
}
