using System;
using System.Collections.Generic;
using Atez.Personal.Api.Models;
using Atez.Personal.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Atez.Personal.Api.Controllers
{
    [ApiController]
    public class EmployeeController : BaseController
    {
        private IEmployeeService employeeService;
        private IOfficeService officeService;

        public EmployeeController(IEmployeeService _employeeService, OfficeService _officeService)
        {
            employeeService = _employeeService;
            officeService = _officeService;
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] CreateEmployeeModel model)
        {
            int termId = new Random().Next();
            var (create, errorMessage) = employeeService.AddEmployee(termId, model.name, model.surname, model.email, model.phone, model.startdatework, model.salary, model.departmantId, model.titleId);
            if (create)
            {
                return Ok(new { status = true });
            }
            return BadRequest(errorMessage);
        }

        [HttpPost]
        public IActionResult GetEmployeesList()
        {
            var (employeeList, errorMessage) = employeeService.GetAvarageSalary();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }
            return Ok(employeeList);
        }

        [HttpPost]
        public IActionResult UpdateEmployeeInfo([FromBody] CreateEmployeeModel model, int employeeId)
        {
            var (updateEmployee, errorMessage) = employeeService.UpdateEmployeeInfo(employeeId, model.name, model.surname, model.email, model.phone, model.startdatework, model.salary, model.departmantId);
            if (updateEmployee)
            {
                return Ok( new { status = true });
            }
            return BadRequest(errorMessage);
        }

        [HttpPost]
        public IActionResult UpdateEmployeeTitle([FromBody] int titleId, int employeeId)
        {
            var (updateEmployee, errorMessage) = employeeService.UpdateEmployeeTitle(employeeId, titleId);
            if (updateEmployee)
            {
                return Ok(new { status = true });
            }
            return BadRequest(errorMessage);
        }

        [HttpPost]
        public IActionResult GetManagerToEmployeesList([FromBody] int model)
        {
            var retVal = new List<EmployeeModel>();
            var (employees, errorMessage) = employeeService.GetManagertoEmployeesList(model);
            foreach (var employee in employees)
            {
                var (department, errorMessage2) = officeService.GetDepartmentInfo(employee.departmentid);
                var (manager, errorMessage4) = employeeService.GetEmployeeInfo(department.managerEmployeeId);
                retVal.Add(new EmployeeModel { id = employee.Id, name = employee.name, surname = employee.surname, email = employee.email, phone = employee.phone,
                    salary = employee.salary, startdatework = employee.startdatework, manager = new EmployeeModel { id=manager.Id, name = manager.name, surname=manager.surname} });
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return Ok(retVal);
        }

        [HttpPost]
        public IActionResult GetAverageSalary()
        {
            var (averageSalary, errorMessage) = employeeService.GetAvarageSalary();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return Ok(averageSalary);
        }
    }
}
