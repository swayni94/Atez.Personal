using System;
using System.Collections.Generic;
using Atez.Personal.Data.Entity;
using Atez.Personal.Data.Repository;
using Atez.Personal.Service.DTOModels;
using Microsoft.Extensions.Logging;

namespace Atez.Personal.Service
{
    public class OfficeService : IOfficeService
    {
        readonly IDepartmentRepository departmentRepository;
        readonly ILocationRepository locationRepository;
        readonly ITitleRepository titleRepository;
        private ILogger<OfficeService> logger;

        public OfficeService(IDepartmentRepository _departmentRepository, ILocationRepository _locationRepository, ITitleRepository _titleRepository, ILogger<OfficeService> _logger)
        {
            
            departmentRepository = _departmentRepository;
            locationRepository = _locationRepository;
            titleRepository = _titleRepository;
            logger = _logger;
        }

        public (bool, string) AddDepartment(int id, string departmentName, int locationId, int managerId)
        {
            var data = new Department();

            data.id = id;
            data.departmenname = departmentName;
            data.locationid = locationId;
            data.managerid = managerId;
            departmentRepository.InsertDepartmentAsync(data);

            return (true, string.Empty);
        }

        public (bool, string) AddLocation(int _id, string _locationName, string _address, string _postCode, string _city, string _country)
        {
            var data = new Location { id = _id, locationname = _locationName, address = _address, postcode = _postCode, city = _city, country=_country };
            locationRepository.InsertLocationAsync(data);
            return (true, string.Empty);
        }

        public (bool, string) AddTitle(int _id, string _titleName, string _startDate, string _endDate, int _departmentId)
        {
            var data = new Title { id = _id, titlename = _titleName, startdate = _startDate, enddate = _endDate, departmentid = _departmentId };
            titleRepository.InsertTitleAsync(data);
            return (true, string.Empty);
        }

        public (DepartmentDTOModel, string) GetDepartmentInfo(int id)
        {
            var department = departmentRepository.GetDepartmentAsync(id).Result;
            var retVal = new DepartmentDTOModel { Id = department.id, departmenname = department.departmenname, locationId = department.locationid, managerEmployeeId = department.managerid};
            return (retVal, string.Empty);
        }

        public (List<DepartmentDTOModel>, string) GetDepartmentList()
        {
            var retVal = new List<DepartmentDTOModel>();
            var departments = departmentRepository.GetDepartmentAsync().Result;
            foreach(var department in departments)
            {
                retVal.Add(new DepartmentDTOModel { Id = department.id, departmenname = department.departmenname, locationId = department.locationid, managerEmployeeId = department.managerid });
            }
            return (retVal, string.Empty);
        }

        public (LocationDTOModel, string) GetLocationInfo(int id)
        {
            var location = locationRepository.GetLocationAsync(id).Result;
            var retVal = new LocationDTOModel { Id = location.id, address = location.address, city = location.city, country = location.country, locationname = location.locationname, postcode = location.postcode };
            return (retVal, string.Empty);
        }

        public (List<LocationDTOModel>, string) GetLocationList()
        {
            var retVal = new List<LocationDTOModel>();
            var locations = locationRepository.GetLocationAsync().Result;
            foreach(var location in locations)
            {
                retVal.Add(new LocationDTOModel { Id = location.id, address = location.address, city = location.city, country = location.country, locationname = location.locationname, postcode = location.postcode });
            }
            return (retVal, string.Empty);
        }


        public (TitleDTOModel, string) GetTitleInfo(int id)
        {
            var title = titleRepository.GetTitleAsync(id).Result;
            var retVal = new TitleDTOModel { Id = title.id, departmentId = title.departmentid, enddate = title.enddate, startdate = title.startdate, titlename = title.titlename };
            return (retVal, string.Empty);
        }

        public (List<TitleDTOModel>, string) GetTitleList()
        {
            var retVal = new List<TitleDTOModel>();
            var titles = titleRepository.GetTitleAsync().Result;
            foreach (var title in titles)
            {
                retVal.Add(new TitleDTOModel { Id = title.id, departmentId = title.departmentid, enddate = title.enddate, startdate = title.startdate, titlename = title.titlename });
            }
            return (retVal, string.Empty);
        }

        public (bool, string) UpdateDepartmentInfo(int departmentid, string udepartmentName, int ulocationId, int umanagerId)
        {
            var entity = departmentRepository.GetDepartmentAsync(departmentid).Result;
            if (!string.IsNullOrEmpty(udepartmentName)) { entity.departmenname = udepartmentName; }
            if (!string.IsNullOrEmpty(ulocationId.ToString())) { entity.locationid = ulocationId; }
            if (!string.IsNullOrEmpty(umanagerId.ToString())) { entity.managerid = umanagerId; }
            var retVal = departmentRepository.UpdateDepartmentAsync(entity).Result;
            return (retVal, string.Empty);
        }

        public (bool, string) UpdateLocationInfo(int locationid, string ulocationName, string uaddress, string upostCode, string ucity, string ucountry)
        {
            var entity = locationRepository.GetLocationAsync(locationid).Result;
            if (!string.IsNullOrEmpty(ulocationName)) { entity.locationname = ulocationName; }
            if (!string.IsNullOrEmpty(uaddress)) { entity.address = uaddress; }
            if (!string.IsNullOrEmpty(upostCode)) { entity.postcode = upostCode; }
            if (!string.IsNullOrEmpty(ucity)) { entity.city = ucity; }
            if (!string.IsNullOrEmpty(ucountry)) { entity.country = ucountry; }
            var retVal = locationRepository.UpdateLocationAsync(entity).Result;
            return (retVal, string.Empty);
        }

        public (bool, string) UpdateTitleInfo(int id, string utitleName, string ustartDate, string uendDate, int udepartmentId)
        {
            var entity = titleRepository.GetTitleAsync(id).Result;
            if (!string.IsNullOrEmpty(utitleName)) { entity.titlename = utitleName; }
            if (!string.IsNullOrEmpty(ustartDate)) { entity.startdate = ustartDate; }
            if (!string.IsNullOrEmpty(uendDate)) { entity.enddate = uendDate; }
            if (!string.IsNullOrEmpty(udepartmentId.ToString())) { entity.departmentid = udepartmentId; }
            var retVal = titleRepository.UpdateTitleAsync(entity).Result;
            return (retVal, string.Empty);
        }
    }
}
