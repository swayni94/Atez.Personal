using System;
using System.Collections.Generic;
using System.Linq;
using Atez.Personal.Data.Entity;
using Atez.Personal.Data.Repository;
using Atez.Personal.Service.DTOModels;
using Microsoft.Extensions.Logging;

namespace Atez.Personal.Service
{
    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeRepository employeeRepository;
        readonly IDepartmentRepository departmentRepository;
        readonly ILocationRepository locationRepository;
        readonly ITitleRepository titleRepository;
        private ILogger<EmployeeService> logger;

        public EmployeeService(IEmployeeRepository _employeeRepository, IDepartmentRepository _departmentRepository, ILocationRepository _locationRepository, ITitleRepository _titleRepository, ILogger<EmployeeService> _logger)
        {
            employeeRepository = _employeeRepository;
            departmentRepository = _departmentRepository;
            locationRepository = _locationRepository;
            titleRepository = _titleRepository;
            logger = _logger;
        }

        public (bool, string) AddEmployee(int id, string name, string surname, string email, string phone, string startdatework, int salary, int departmentid, int titleid)
        {
            var data = new Employee();
            data.id = id;
            data.name = name;
            data.surname = surname;
            data.email = email;
            data.phone = phone;
            data.startdatework = startdatework;
            data.salary = salary;
            data.departmentid = departmentid;
            data.titleid = titleid;
            employeeRepository.InsertEmployeeAsync(data);

            return (true, string.Empty);
        }

        public (List<DepartmentDTOModel>, string) GetAvarageSalary()
        {
            var term = new double();
            var retVal = new List<DepartmentDTOModel>();
            var departments = departmentRepository.GetDepartmentAsync().Result;
            foreach (var item in departments)
            {
                var employees = employeeRepository.GetEmployeesInDepartmentAsync(item.id).Result;
                term = 0;
                foreach (var employee in employees)
                {
                    term = (term + employee.salary)/2;
                }
                retVal.Add(new DepartmentDTOModel{Id = item.id, departmenname = item.departmenname, locationId=item.locationid, managerEmployeeId = item.managerid, avarageSalary=term});
            }
            return (retVal, string.Empty);
        }

        public (EmployeeDTOModel, string) GetEmployeeInfo(int id)
        {
            var item = employeeRepository.GetEmployeeAsync(id).Result;
            var retVal = new EmployeeDTOModel { Id = item.id, name = item.name, surname = item.surname, email = item.email, phone = item.phone, salary = item.salary, startdatework = item.startdatework, departmentid = item.departmentid, titleid = item.titleid };
            return (retVal, string.Empty);
        }

        public (List<EmployeeDTOModel>, string) GetEmployeesList()
        {
            var retVal = new List<EmployeeDTOModel>();
            var employees = employeeRepository.GetEmployeeAsync().Result;
            foreach (var item in employees)
            {
                retVal.Add(new EmployeeDTOModel { Id = item.id, name = item.name, surname = item.surname, email = item.email, phone = item.phone, salary = item.salary, startdatework = item.startdatework, departmentid = item.departmentid, titleid = item.titleid });
            }
            return (retVal, string.Empty);
        }

        public (List<EmployeeDTOModel>, string) GetManagertoEmployeesList(int managerid)
        {
            var retVal = new List<EmployeeDTOModel>();
            var employees = employeeRepository.GetEmployeeAsync().Result.OrderBy(w => w.departmentid);
            foreach (var item in employees)
            {
                retVal.Add(new EmployeeDTOModel { Id = item.id, name = item.name, surname = item.surname, email = item.email, phone = item.phone, salary = item.salary, startdatework = item.startdatework, departmentid = item.departmentid, titleid = item.titleid });
            }
            return (retVal, string.Empty);
        }

        public (bool, string) UpdateEmployeeInfo(int employeeid, string uname, string usurname, string uemail, string uphone, string ustartdatework, int usalary, int udepartmentid)
        {
            var entity = new Employee();
            entity = employeeRepository.GetEmployeeAsync(employeeid).Result;
            if (!string.IsNullOrEmpty(uname)) { entity.name = uname; }
            if (!string.IsNullOrEmpty(usurname)) { entity.surname = usurname; }
            if (!string.IsNullOrEmpty(uemail)) { entity.email = uemail; }
            if (!string.IsNullOrEmpty(uphone)) { entity.phone = uphone; }
            if (!string.IsNullOrEmpty(ustartdatework)) { entity.startdatework = ustartdatework; }
            if (!string.IsNullOrEmpty(usalary.ToString())) { entity.salary = usalary; }
            if (!string.IsNullOrEmpty(udepartmentid.ToString())) { entity.departmentid = udepartmentid; }
            var retVal = employeeRepository.UpdateEmployeeAsync(entity).Result;
            return (retVal, string.Empty);
        }

        public (bool, string) UpdateEmployeeTitle(int employeeid, int titleid)
        {
            var entity = new Employee();
            entity = employeeRepository.GetEmployeeAsync(employeeid).Result;
            if (!string.IsNullOrEmpty(titleid.ToString())) { entity.titleid = titleid; }
            var retVal = employeeRepository.UpdateEmployeeAsync(entity).Result;
            return (retVal, string.Empty);
        }
    }
}
