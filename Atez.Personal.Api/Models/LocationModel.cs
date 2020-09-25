using System;
namespace Atez.Personal.Api.Models
{
    public class LocationModel : BaseModel
    {
        public string locationname { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}
