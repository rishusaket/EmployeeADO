using EmployeeADO.EmployeeDAL;
using EmployeeADO.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeADO.EmplyeeBAL
{
    public class EmployeeBusiness
    {
        private readonly IEmployeeDataAccess dataAccess = new EmployeeDataAccess();
        public bool addEmployee(Employee employee)
        {
            return dataAccess.AddEmployee(employee);
        }
        public IEnumerable<Employee> Display()
        {
            return dataAccess.EmployeeList();
        }
        public void deleteEmployee(int id)
        {
            dataAccess.DeleteEmployee(id);
        }
        public void EditEmployee(Employee employee)
        {
            dataAccess.editEmployee(employee);
        }
        public bool isLocationAvailable(string location)
        {
            return dataAccess.LocationAvailable(location);
        }
    }
}
