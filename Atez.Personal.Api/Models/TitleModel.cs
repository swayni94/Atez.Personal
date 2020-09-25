using System;
namespace Atez.Personal.Api.Models
{
    public class TitleModel : BaseModel
    {
        public string titlename { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public DepartmentModel department { get; set; }
    }
}
