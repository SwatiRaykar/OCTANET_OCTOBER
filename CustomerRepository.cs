using DAL.Interface;
using DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using FluentAssertions.Common;
using Newtonsoft.Json;

namespace UdemyProj.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _configuration;

        public CustomerRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            //SqlConnection con = new SqlConnection();

            return null;
        }

        public int RegisterCustomer(User user)
        //public int RegisterCustomer(string FirstName, string LastName, string EmailId, string Password, string PhoneNumber)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BBDCon"));

            SqlCommand cmd = new SqlCommand("[CB_RegisterCustomer]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            /*  cmd.Parameters.Add("@FirstName",SqlDbType.VarChar); */
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@EmailId", user.EmailId);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);


            /*SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
             int NoOfRow=adapter.Fill(dt);
             return 1; */
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public userLogedIn CustomerLogin(Login login)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BBDCon"));
                con.Open();
                SqlCommand cmd = new SqlCommand("[CB_CustomerLogin]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmailId", login.EmailId);
                cmd.Parameters.AddWithValue("@Password", login.Password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userLogedIn user = new userLogedIn
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            Name = reader["Name"].ToString(),
                             EmailId = reader["EmailId"].ToString()
                        };

                        return user;
                    }
                    return null;// Invalid login credentials
                }

                con.Close();
            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(System.Diagnostics.Tracing.EventLevel.Error, ex);
                throw new Exception(ex.Message);
            }
        }


        public ForgotPassword ForgotPassword(ForgotPwd forgot)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BBDCon"));
                con.Open();
                SqlCommand cmd = new SqlCommand("[CB_ForgotPassword]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmailId", forgot.EmailId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ForgotPassword fp = new ForgotPassword
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            UserName = reader["UserName"].ToString(),
                            Token = reader["Token"].ToString()
                        };

                        return fp;
                    }
                    return null;// Invalid email
                }

                con.Close();
            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(System.Diagnostics.Tracing.EventLevel.Error, ex);
                throw new Exception(ex.Message);
            }
        }


        public int ResetPassword(ResetPwd reset)
        //public int RegisterCustomer(string FirstName, string LastName, string EmailId, string Password, string PhoneNumber)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BBDCon"));

            SqlCommand cmd = new SqlCommand("[FE_ResetPassword]", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmailId", reset.EmailId);
            cmd.Parameters.AddWithValue("@Token", reset.Token);
            cmd.Parameters.AddWithValue("@NewPassword", reset.NewPassword);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
       

        public AppointmentDetails BookAppointment(Appointment appointment)
        //public int RegisterCustomer(string FirstName, string LastName, string EmailId, string Password, string PhoneNumber)
        {
            try
            {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BBDCon")); 
            con.Open();
            SqlCommand cmd = new SqlCommand("[Z_AppCustomer]", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", appointment.Name);
            cmd.Parameters.AddWithValue("@Address", appointment.Address);
            cmd.Parameters.AddWithValue("@EmailId", appointment.EmailId);
            cmd.Parameters.AddWithValue("@Date", appointment.Date);
            cmd.Parameters.AddWithValue("@PhoneNumber", appointment.PhoneNumber);
            cmd.Parameters.AddWithValue("@Services", JsonConvert.SerializeObject(appointment.Services)); // Convert array to comma-separated string



                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        AppointmentDetails Appdetails = new AppointmentDetails
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            EmailId = reader["EmailId"].ToString(),
                            Date = reader["Date"].ToString(),
                            PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]),
                            Services = reader["Services"].ToString(),

                        };

                        return Appdetails;
                    }
                    return null;// Invalid email
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(System.Diagnostics.Tracing.EventLevel.Error, ex);
                throw new Exception(ex.Message);
            }
        }

        public ContactDetails ContactUs(Contact contact)
        //public int RegisterCustomer(string FirstName, string LastName, string EmailId, string Password, string PhoneNumber)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BBDCon"));
                con.Open();
                SqlCommand cmd = new SqlCommand("[Z_custContact]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@EmailId", contact.EmailId);
                cmd.Parameters.AddWithValue("@Message", contact.Message);



                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       ContactDetails details = new ContactDetails
                       {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            Name = reader["Name"].ToString(),
                            EmailId = reader["EmailId"].ToString(),
                            message = reader["Message"].ToString(),

                        };

                        return details;
                    }
                    return null;// Invalid email
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogExceptionMessage(System.Diagnostics.Tracing.EventLevel.Error, ex);
                throw new Exception(ex.Message);
            }
        }

    }
}

