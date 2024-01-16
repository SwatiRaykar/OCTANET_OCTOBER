using EmployeePaySlip.Interface;
using EmployeePaySlip.Models;
using EmployeePaySlip.Models.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeePaySlip.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> lst = new List<Employee>();
            try
            {


                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MvcConn"));

                SqlCommand cmd = new SqlCommand("[GetAllEmployee]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee cst = new Employee();
                    cst.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                    cst.EmpCode = dt.Rows[i]["EmpCode"].ToString();
                    cst.FirstName = dt.Rows[i]["FirstName"].ToString();
                    cst.LastName = dt.Rows[i]["LastName"].ToString();
                    cst.DOB = dt.Rows[i]["LastName"].ToString();

                    cst.BasicSal = int.Parse(dt.Rows[i]["BasicSal"].ToString());
                    cst.TA = int.Parse(dt.Rows[i]["TA"].ToString());
                    cst.HRA = int.Parse(dt.Rows[i]["HRA"].ToString());
                    cst.Gross = int.Parse(dt.Rows[i]["Gross"].ToString());
                    cst.ProvidentFund = int.Parse(dt.Rows[i]["ProvidentFund"].ToString());
                    cst.ProfessionalTax = int.Parse(dt.Rows[i]["ProfessionalTax"].ToString());
                    cst.NetSalary = int.Parse(dt.Rows[i]["NetSalary"].ToString());

                    lst.Add(cst);

                }
                return lst.ToList();
            }
            catch (Exception)
            {
                throw;
            }


        }

        public void AddEmployee(AddEmpViewModel employee)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MvcConn"));

            try
            {

                SqlCommand cmd = new SqlCommand("[AddEmployee]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpCode", employee.EmpCode);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                cmd.Parameters.AddWithValue("@BasicSal", employee.BasicSal);
                cmd.Parameters.AddWithValue("@TA", employee.TA);
                cmd.Parameters.AddWithValue("@HRA", employee.HRA);
                cmd.Parameters.AddWithValue("@Gross", employee.Gross);
                cmd.Parameters.AddWithValue("@ProvidentFund", employee.ProvidentFund);
                cmd.Parameters.AddWithValue("@ProfTax", employee.ProfTax);
                cmd.Parameters.AddWithValue("@NeTSalary", employee.NetSalary);

                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();

            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection("MvcConn"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("[RemoveEmployee]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
       
        public List<Employee> GetEmpById(int id,string name)
        {
            
                using (SqlConnection connection = new SqlConnection("MvcConn"))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("[GetEmpbyId]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Name", name);


                    using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Employee result = new Employee
                                
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    EmpCode = reader["EmpCode"].ToString(),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    DOB = reader["DOB"].ToString(),
                                    BasicSal = int.Parse((string)reader["BasicSal"]),
                                    TA = int.Parse((string)reader["TA"]),
                                    HRA = int.Parse((string)reader["HRA"]),
                                    Gross = int.Parse((string)reader["Gross"]),
                                    ProvidentFund = int.Parse((string)reader["ProvidentFund"]),
                                    ProfessionalTax = int.Parse((string)reader["ProfTax"]),
                                    NetSalary = int.Parse((string)reader["NetSalary"]),
                                };
                                return result;
                            }
                            else { return null; }
                        }
                    }
                }

                
            
        }
        public void Update  (Employee employee)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("MvcConn"));

            con.Open();

                using (SqlCommand cmd = new SqlCommand("[EditEmployee]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@EmpCode", employee.EmpCode);
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                    cmd.Parameters.AddWithValue("@BasicSal", employee.BasicSal);
                    cmd.Parameters.AddWithValue("@TA", employee.TA);
                    cmd.Parameters.AddWithValue("@HRA", employee.HRA);
                    cmd.Parameters.AddWithValue("@Gross", employee.Gross);
                    cmd.Parameters.AddWithValue("@ProvidentFund", employee.ProvidentFund);
                    cmd.Parameters.AddWithValue("@ProfTax", employee.ProfessionalTax);
                    cmd.Parameters.AddWithValue("@NeTSalary", employee.NetSalary);

                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();
                }
            
        }
    }
}
    

