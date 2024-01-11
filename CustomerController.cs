using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using DAL.Models;
using DAL.Interface;
using System.Data;
using System.Collections.Generic;
using UdemyProj.Repository;
using System.Diagnostics.Eventing.Reader;

namespace UdemyProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       // private readonly AppSettings _appSettings;

        private readonly IConfiguration _configuration;
        private readonly ICustomerRepository _customer;
        /*  public CustomerController(IOptions<AppSettings> appSettings, ICustomerRepository customer)
          {
              _appSettings = appSettings.Value;
              this._customer = customer;


          }*/

        public CustomerController(IConfiguration config, ICustomerRepository customer)
          {
            _configuration = config;
            _customer = customer;
          }
        //Don't remove this
        [HttpGet]
      public IActionResult Index()
      {
          var constr = _configuration.GetConnectionString("BBDCon");
          return Ok(constr);
      }
        [HttpGet("GetAllCustomers")]
        public List<Customers> GetAllCustomers()
        {

            var apiResponse = new APIResponse();
            
                List<Customers> lst = new List<Customers>();
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BBDCon"));

                SqlCommand cmd = new SqlCommand("[GetAllCustomers]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Customers cst = new Customers();
                    cst.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                    cst.EmailId = dt.Rows[i]["EmailId"].ToString();
                    cst.FirstName = dt.Rows[i]["FirstName"].ToString();


                    lst.Add(cst);

                }

                return lst;

            
           
        }
        [AllowAnonymous]
        [HttpPost("RegisterCustomer")]
       public IActionResult RegisterCustomer([FromBody] User user)

        //public IActionResult RegisterCustomer(Customer cust)
        {
            var apiResponse = new APIResponse();
            var newCustomer =   _customer.RegisterCustomer(user);
            if (newCustomer != 0)
            {
                apiResponse.Success = true;
                apiResponse.Data = "Successfully registered";
                SendMailUtility1.MEmail.SendRegistrationEmail(user.EmailId, user.FirstName);

            }
            else
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage = "Failed to create customer with provided input";
            }

            return Ok(apiResponse);
        }


        [AllowAnonymous]
        [HttpPost("CustomerLogin")]
        public ActionResult<userLogedIn> CustomerLogin([FromBody] Login login)
        {
            var response = new APIResponse();
            try
            {
                userLogedIn  user = _customer.CustomerLogin(login);
                if (user != null)
                {
                    response.Success = true;
                    //response.Data = customers;
                   // response.Data = user.Name+" Login Successful !";
                    response.Data=user;
                }
                else
                {
                    response.Success = false;
                    response.Data = "Invalid User";

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return Ok(response);

        }


        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public ActionResult<ForgotPassword>ForgotPassword([FromBody] ForgotPwd forgot)
        {
            var response = new APIResponse();
            try
            {
                ForgotPassword user = _customer.ForgotPassword(forgot);
                if (user != null)
                {
                    response.Success = true;
                    //response.Data = customers;
                     response.Data = " mail send Successfully !";
                    //.Data = user
                    SendMailUtility1.MEmail.ForgotPWDToken(user, forgot.EmailId);
                    response.Data = " mail send Successfully !";

                }
                else
                {
                    response.Success = false;
                    response.Data = "Invalid User";

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return Ok(response);

        }

        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPwd reset)
        {
            var apiResponse = new APIResponse();
            var newCustomer = _customer.ResetPassword(reset);
            if (newCustomer != 0)
            {
                apiResponse.Success = true;
                apiResponse.Data = "Password has been changed !";

            }
            else
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage = "Failed to reset password";
            }

            return Ok(apiResponse);
        }

        [AllowAnonymous]
        [HttpPost("BookAppointment")]
        public ActionResult<AppointmentDetails> BookAppointment([FromBody] Appointment appointment)

        {  
            // var appointment=new Appointment { Services=dataArray};

            var apiResponse = new APIResponse();
            AppointmentDetails CustomerApp = _customer.BookAppointment(appointment);
            if (CustomerApp != null)
            {
                apiResponse.Success = true;
                apiResponse.Data = "Appointment Send. ";
                SendMailUtility1.MEmail.Appointment(CustomerApp);

            }
            else
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage = "Failed to send appointment";
            }

            return Ok(apiResponse);
        }

        [AllowAnonymous]
        [HttpPost("ContactUs")]
        public ActionResult<ContactDetails> ContactUs([FromBody] Contact contact)

        {
            // var appointment=new Appointment { Services=dataArray};

            var apiResponse = new APIResponse();
            ContactDetails contactCust = _customer.ContactUs(contact);
            if (contactCust != null)
            {
                apiResponse.Success = true;
                apiResponse.Data = "Message Send. ";
                SendMailUtility1.MEmail.Contact_Us(contactCust);

            }
            else
            {
                apiResponse.Success = false;
                apiResponse.ErrorMessage = "Failed to sent message";
            }

            return Ok(apiResponse);
        }

    }
}
