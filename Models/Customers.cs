using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Customers
    {

        public int Id { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        //public string Password { get; set; }
        //public BigInteger PhoneNumber { get; set; }

    }
  
    public class ForgotPassword
    {
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
    public class ForgotPwd
    {
        public string EmailId { get; set; }

    }

    public class ResetPwd
    {
        public string EmailId { get; set; }
        public string Token{ get; set; }
        public string NewPassword { get; set; }



    }



}

