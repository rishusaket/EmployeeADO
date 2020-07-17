using EmployeeADO.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmployeeADO.EmployeeDAL
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private SqlConnection con;
        private void connection()
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\M1049078\\source\\repos\\EmployeeADO\\EmployeeDAL\\EmployeeData.mdf;Integrated Security=True");
        }
        public bool AddEmployee(Employee employee)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", employee.name);
            cmd.Parameters.AddWithValue("@gender", employee.gender);
            cmd.Parameters.AddWithValue("@location", employee.location);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Employee> EmployeeList()
        {
            using(var connection=new SqlConnection(""))
            {
                using(var command=new SqlCommand("", connection))
                {

                }
            }
            connection();
            List<Employee> employees = new List<Employee>();
            SqlCommand cmd = new SqlCommand("ViewEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            con.Open();
            dataAdapter.Fill(dataTable);
            con.Close();

            foreach (DataRow row in dataTable.Rows)
                employees.Add(new Employee()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    name = Convert.ToString(row["name"]),
                    gender = Convert.ToString(row["gender"]),
                    location = Convert.ToString(row["location"])
                });

            return employees;
        }
        public void DeleteEmployee(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void editEmployee(Employee employee)
        {
            connection();
            SqlCommand cmd = new SqlCommand("EditEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", employee.Id);
            cmd.Parameters.AddWithValue("@name", employee.name);
            cmd.Parameters.AddWithValue("@gender", employee.gender);
            cmd.Parameters.AddWithValue("@location", employee.location);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        public bool LocationAvailable(string location)
        {
            return EmployeeList().Any(x => x.location == location);
        }
    }
}
