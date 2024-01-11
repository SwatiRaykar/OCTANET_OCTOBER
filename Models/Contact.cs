using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
  public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Message { get; set; }

    }

    public class ContactDetails
    {

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string message { get; set; }

    }
}
