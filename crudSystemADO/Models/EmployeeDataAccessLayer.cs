using crudSystemADO.Utility;
using MySqlConnector;
using System.Data;

namespace crudSystemADO.Models
{
	public class EmployeeDataAccessLayer
	{
		string connectionString = ConnectionString.CName;

		public IEnumerable<Employee> GetAllEmployee()
		{
			List<Employee> listEmployee = new List<Employee>();
			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				MySqlCommand cmd = new MySqlCommand("ViewEmployees", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				MySqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					Employee employee = new Employee();
					employee.Id = Convert.ToInt32(rdr["Id"]);
					employee.FirstName = rdr["FirstName"].ToString();
					employee.LastName = rdr["LastName"].ToString();
					employee.Status = Convert.ToBoolean(rdr["Status"]);
					employee.State = rdr["State"].ToString();
					employee.CheckBox1 = rdr["CheckBox1"].ToString();
					employee.CheckBox2 = rdr["CheckBox2"].ToString();
					listEmployee.Add(employee);
				}
				con.Close();
			}
			return listEmployee;
		}
		public void AddEmployee(Employee employee)
		{
			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				MySqlCommand cmd = new MySqlCommand("AddEmployee", con);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("p_firstname", employee.FirstName);
				cmd.Parameters.AddWithValue("p_lastname", employee.LastName);
				cmd.Parameters.AddWithValue("p_status", employee.Status);
				cmd.Parameters.AddWithValue("p_state", employee.State);
				cmd.Parameters.AddWithValue("p_checkbox1", employee.CheckBox1);
				cmd.Parameters.AddWithValue("p_checkbox2", employee.CheckBox2);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void UpdateEmployee(Employee employee)
		{
			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				MySqlCommand cmd = new MySqlCommand("UpdateEmployee", con);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("p_Id", employee.Id);
				cmd.Parameters.AddWithValue("p_FirstName", employee.FirstName);
				cmd.Parameters.AddWithValue("p_LastName", employee.LastName);
				cmd.Parameters.AddWithValue("p_Status", employee.Status);
				cmd.Parameters.AddWithValue("p_State", employee.State);
				cmd.Parameters.AddWithValue("p_CheckBox1", employee.CheckBox1);
				cmd.Parameters.AddWithValue("p_CheckBox2", employee.CheckBox2);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public Employee GetEmployeeData(int? id)
		{
			Employee employee = new Employee();

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				string mysqlQuery = "SELECT * FROM tbl_employees WHERE Id= " + id;
				MySqlCommand cmd = new MySqlCommand(mysqlQuery, con);
				con.Open();
				MySqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					employee.Id = Convert.ToInt32(rdr["Id"]);
					employee.FirstName = rdr["FirstName"].ToString();
					employee.LastName = rdr["LastName"].ToString();
					employee.Status = Convert.ToBoolean(rdr["Status"]);
					employee.State = rdr["State"].ToString();
					employee.CheckBox1 = rdr["CheckBox1"].ToString();
					employee.CheckBox2 = rdr["CheckBox2"].ToString();
				}
			}
			return employee;
		}

		public void DeleteEmployee(int? id)
		{
			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				MySqlCommand cmd = new MySqlCommand("DeleteEmployee", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("p_id", id);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}
	}
}
