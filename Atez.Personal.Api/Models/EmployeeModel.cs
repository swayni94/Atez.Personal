using System;
namespace Atez.Personal.Api.Models
{
    public class EmployeeModel : BaseModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string startdatework { get; set; }
        public int salary { get; set; }
        public DepartmentModel department { get; set; }
        public TitleModel title { get; set; }
        public EmployeeModel manager { get; set; }
    }
}
