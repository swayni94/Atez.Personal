using System;
using System.Collections.Generic;
using Atez.Personal.Service.DTOModels;

namespace Atez.Personal.Service
{
    public interface IOfficeService
    {
        //TO MANAGE DEPARTMENT
        (bool, string) AddDepartment(int id, string departmentName, int locationId, int managerId);
        (bool, string) UpdateDepartmentInfo(int departmentid, string udepartmentName, int ulocationId, int umanagerId);
        (DepartmentDTOModel, string) GetDepartmentInfo(int id);
        (List<DepartmentDTOModel>, string) GetDepartmentList();

        // to manage Location
        (bool, string) AddLocation(int id, string locationName, string address, string postCode, string city, string country);
        (bool, string) UpdateLocationInfo(int locationid, string ulocationName, string uaddress, string upostCode, string ucity, string ucountry);
        (LocationDTOModel, string) GetLocationInfo(int id);
        (List<LocationDTOModel>, string) GetLocationList();

        // to manage Title
        (bool, string) AddTitle(int id, string titleName, string startDate, string endDate, int departmentId);
        (bool, string) UpdateTitleInfo(int id, string utitleName, string ustartDate, string uendDate, int udepartmentId);
        (TitleDTOModel, string) GetTitleInfo(int id);
        (List<TitleDTOModel>, string) GetTitleList();
    }
}
