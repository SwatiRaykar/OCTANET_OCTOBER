using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetAllCustomers();
        // int RegisterCustomer(string FirstName, string LastName, string EmailId, string Password, string PhoneNumber);
        int RegisterCustomer(User user);

        userLogedIn CustomerLogin(Login login);

        ForgotPassword ForgotPassword(ForgotPwd forgot);
        int ResetPassword(ResetPwd reset);
        AppointmentDetails BookAppointment(Appointment appointment);
        ContactDetails ContactUs(Contact contact);
        //Task<int> SignUpUser(User user);


        // ForgotPassword ForgotPassword(string EmailId);
    }
}
