using System;
namespace Atez.Personal.Api.Models
{
    public class CreateTitleModel : BaseModel
    {
        public string titlename { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public int departmentid { get; set; }
    }
}
