using EmployeeADO.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeADO.EmployeeDAL
{
    public interface IEmployeeDataAccess
    {
        bool AddEmployee(Employee employee);
        List<Employee> EmployeeList();
        void DeleteEmployee(int id);
        void editEmployee(Employee employee);
        bool LocationAvailable(string location);
    }
}
