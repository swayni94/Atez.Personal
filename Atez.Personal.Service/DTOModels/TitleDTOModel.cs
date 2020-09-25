namespace Atez.Personal.Service.DTOModels
{
    public class TitleDTOModel : BaseDTOModel
    {
        public string titlename { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public int departmentId { get; set; }
    }
}
