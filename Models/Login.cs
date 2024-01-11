using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   
    public class Login
    {
        public string EmailId { get; set; }

        public string Password { get; set; }

        // public int CustomerId { get; set; }
    }

    public class userLogedIn
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
    }
}
