using System;
namespace Atez.Personal.Api.Models
{
    public class CreateEmployeeModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string startdatework { get; set; }
        public int salary { get; set; }
        public int departmantId { get; set; }
        public int titleId { get; set; }
    }
}
