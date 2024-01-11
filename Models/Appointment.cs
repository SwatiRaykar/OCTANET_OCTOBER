using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
     public class Appointment
     {
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string Date { get; set; }
        public long PhoneNumber { get; set; }
        public string[]  Services { get; set; }
     }

    public class AppointmentDetails
    {

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string Date { get; set; }
        public long PhoneNumber { get; set; }
        public string Services { get; set; }
    }


}
