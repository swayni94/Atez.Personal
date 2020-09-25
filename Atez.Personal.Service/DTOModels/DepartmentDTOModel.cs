namespace Atez.Personal.Service.DTOModels
{
    public class DepartmentDTOModel : BaseDTOModel
    {
        public string departmenname { get; set; }
        public int managerEmployeeId { get; set; }
        public int locationId { get; set; }
        public double avarageSalary { get; set; }
    }
}
