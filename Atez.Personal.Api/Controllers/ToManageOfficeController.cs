using System;
using Atez.Personal.Api.Models;
using Atez.Personal.Service;
using Microsoft.AspNetCore.Mvc;

namespace Atez.Personal.Api.Controllers
{
    [ApiController]
    public class ToManageOfficeController : BaseController
    {
        private IOfficeService officeService;

        public ToManageOfficeController(IOfficeService _officeService)
        {
            officeService = _officeService;
        }

        [HttpPost]
        public IActionResult CreateDepartment([FromBody] CreateDepartmentModel model)
        {
            var termId = new Random().Next();

            var (create, errorMessage) = officeService.AddDepartment(termId, model.departmenname, model.locationid, model.managerid);
            if (create)
            {
               return Ok(new { status = true });
            }
            return BadRequest(errorMessage);
        }

        [HttpPost]
        public IActionResult CreateLocation([FromBody] LocationModel model)
        {
            var termId = new Random().Next();

            var (create, errorMessage) = officeService.AddLocation(termId,model.locationname, model.address, model.postcode, model.city, model.country);
            if (create)
            {
                return Ok(new { status = true });
            }
            return BadRequest(errorMessage);
        }

        [HttpPost]
        public IActionResult CreateTitle([FromBody] CreateTitleModel model)
        {
            var termId = new Random().Next();

            var (create, errorMessage) = officeService.AddTitle(termId, model.titlename, model.startdate, model.enddate, model.departmentid);
            if (create)
            {
                return Ok(new { status = true });
            }
            return BadRequest(errorMessage);
        }

        [HttpPost]
        public IActionResult UpdateDepartment([FromBody] CreateDepartmentModel model, int departmentId)
        {
            var (update, errorMessage) = officeService.UpdateDepartmentInfo(departmentId, model.departmenname, model.locationid, model.managerid);
            if (update)
            {
                return Ok(new { status = true });
            }
            return BadRequest(errorMessage);
        }

        [HttpPost]
        public IActionResult UpdateLocation([FromBody] LocationModel model, int locationtId)
        {
            var (update, errorMessage) = officeService.UpdateLocationInfo(locationtId, model.locationname, model.address, model.postcode, model.city, model.country);
            if (update)
            {
                return Ok(new { status = true });
            }
            return BadRequest(errorMessage);
        }

        [HttpPost]
        public IActionResult UpdateTitle([FromBody] CreateTitleModel model, int titleId)
        {
            var (update, errorMessage) = officeService.UpdateTitleInfo(titleId, model.titlename, model.startdate, model.enddate, model.departmentid);
            if (update)
            {
                return Ok(new { status = true });
            }
            return BadRequest(errorMessage);
        }

        [HttpPost]
        public IActionResult GetDepartmentList()
        {
            var (departments, errorMessage) = officeService.GetDepartmentList();
            if (string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult GetDepartmentInfo([FromBody] int departmentId)
        {
            var (department, errorMessage) = officeService.GetDepartmentInfo(departmentId);
            if (string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }
            return Ok(department);
        }

        [HttpPost]
        public IActionResult GetLocationList()
        {
            var (locations, errorMessage) = officeService.GetLocationList();
            if (string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }
            return Ok(locations);
        }

        [HttpPost]
        public IActionResult GetLocationInfo([FromBody] int locationId)
        {
            var (location, errorMessage) = officeService.GetLocationInfo(locationId);
            if (string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }
            return Ok(location);
        }

        [HttpPost]
        public IActionResult GetTitleList()
        {
            var (titles, errorMessage) = officeService.GetTitleList();
            if (string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }
            return Ok(titles);
        }

        [HttpPost]
        public IActionResult GetTitleInfo([FromBody] int titleId)
        {
            var (title, errorMessage) = officeService.GetDepartmentInfo(titleId);
            if (string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }
            return Ok(title);
        }
    }
}
