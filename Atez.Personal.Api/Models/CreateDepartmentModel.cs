using System;
namespace Atez.Personal.Api.Models
{
    public class CreateDepartmentModel : BaseModel
    {
        public string departmenname { get; set; }
        public int managerid { get; set; }
        public int locationid { get; set; }
    }
}
