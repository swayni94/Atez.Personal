using System;
namespace Atez.Personal.Api.Models
{
    public class DepartmentModel : BaseModel
    {
        public string departmenname { get; set; }
        public EmployeeModel manager { get; set; }
        public LocationModel location { get; set; }
    }
}
