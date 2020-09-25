using System;
using System.Collections.Generic;
using Atez.Personal.Service.DTOModels;

namespace Atez.Personal.Service
{
    public interface IEmployeeService
    {
        (bool, string) AddEmployee(int id, string name, string surname, string email, string phone, string startdatework, int salary, int departmentid, int titleid);
        (bool, string) UpdateEmployeeInfo(int employeeid, string uname, string usurname, string uemail, string uphone, string ustartdatework, int usalary, int udepartmentid);
        (EmployeeDTOModel, string) GetEmployeeInfo(int id);
        (bool, string) UpdateEmployeeTitle(int employeeid, int titleid);
        (List<EmployeeDTOModel>, string) GetManagertoEmployeesList(int managerid);
        (List<EmployeeDTOModel>, string) GetEmployeesList();
        (List<DepartmentDTOModel>, string) GetAvarageSalary();
        //
    }
}
