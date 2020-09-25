namespace Atez.Personal.Service.DTOModels
{
    public class LocationDTOModel : BaseDTOModel
    {
        public string locationname { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}
