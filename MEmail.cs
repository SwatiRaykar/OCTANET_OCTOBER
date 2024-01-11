
    // See https://aka.ms/new-console-template for more information
    //Console.WriteLine("Hello, World!");
    using System.Data;
using System.Web;
using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
using System.Net.Security;
using MimeKit;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Org.BouncyCastle.Asn1.X509;
using DAL.Models;

namespace SendMailUtility1
{
  

    public class MEmail
    {
       
        //Registration
        public static string SendRegistrationEmail(string EmailId,string Username)
        {
                using SmtpClient email = new SmtpClient
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587,
                   Credentials = new NetworkCredential(userName: "bestbulliondeals@gmail.com", "ngurskzdvdkinept")
                   // Credentials = new NetworkCredential(userName: "swatiraykar448@gmail.com", "byynltytthlsdaoz")
                };

            string path = "C:\\Users\\Swati\\AngularUK\\UdemyProj\\SendMailUtility1\\Template\\RegistrationSuccess.html";
            string body = File.ReadAllText(path);
            body = body.Replace("{CUSTOMER_NAME}", Username);
            //MailMessage message = new MailMessage("swatiraykar448@gmail.com",EmailId,"Bullion Mentor",body);

            MailMessage message = new MailMessage("bestbulliondeals@gmail.com", EmailId,"Nature Looks",body);
            message.IsBodyHtml = true;
               try
               {
                //Console.WriteLine("Sending..");
                email.Send(message);
                 //Console.WriteLine("Sent.");
               }
               catch (SmtpException ex)
               {
                Console.WriteLine(ex);
               }
              return EmailId;
        }


        //Forgot Password
        public static string ForgotPWDToken(ForgotPassword forgotPassword1, string EmailId)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                //Credentials = new NetworkCredential(userName: FromAddress, Password2)
                Credentials = new NetworkCredential(userName: "bestbulliondeals@gmail.com", "ngurskzdvdkinept")
            };

           
            string path = "C:\\Users\\Swati\\AngularUK\\UdemyProj\\SendMailUtility1\\Template\\ForgotPWDToken.html";
           // ForgotPassword1 token = new ForgotPassword1();
            string body = File.ReadAllText(path);
            body = body.Replace("{RESET_PASSWORD_LINK}", "http://localhost:4200/reset-pwd");
       
            body = body.Replace("{TOKEN}", forgotPassword1.Token);
            body = body.Replace("{CUSTOMER_NAME}", forgotPassword1.UserName);
            MailMessage message = new MailMessage("bestbulliondeals@gmail.com", EmailId, "Nature Looks", body);
            message.IsBodyHtml = true;
            try
            {
                email.Send(message);
                //email.Send("swatiraykar448@gmail.com", recipients: EmailId, subject, body);

            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex);
            }
            return EmailId;
        }

        // Appointment
        public static string Appointment(AppointmentDetails appointDetails)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                //Credentials = new NetworkCredential(userName: FromAddress, Password2)
                Credentials = new NetworkCredential(userName: "bestbulliondeals@gmail.com", "ngurskzdvdkinept")
            };


            string path = "C:\\Users\\Swati\\AngularUK\\UdemyProj\\SendMailUtility1\\Template\\NewAppoinmentDetails.html";
            // ForgotPassword1 token = new ForgotPassword1();
            string body = File.ReadAllText(path);
            body = body.Replace("{RESET_PASSWORD_LINK}", "http://localhost:4200/reset-pwd");

            body = body.Replace("{CUSTOMER_ID}", appointDetails.CustomerId.ToString());
            body = body.Replace("{CUSTOMER_NAME}", appointDetails.Name);
            body = body.Replace("{ADDRESS}", appointDetails.Address);
            body = body.Replace("{EMAIL_ID}", appointDetails.EmailId);
            body = body.Replace("{DATE}", appointDetails.Date);
            body = body.Replace("{PHONE_NUMBER}", appointDetails.PhoneNumber.ToString());
            body = body.Replace("{CUSTOMER_Req_SERVICES}", appointDetails.Services);

            MailMessage message = new MailMessage("bestbulliondeals@gmail.com","swatiraykar448@gmail.com", "Nature Looks", body);
            message.IsBodyHtml = true;
            try
            {
                email.Send(message);
                //email.Send("swatiraykar448@gmail.com", recipients: EmailId, subject, body);

            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
        // ContactUs
        public static string Contact_Us(ContactDetails contact)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                //Credentials = new NetworkCredential(userName: FromAddress, Password2)
                Credentials = new NetworkCredential(userName: "bestbulliondeals@gmail.com", "ngurskzdvdkinept")
            };


            string path = "C:\\Users\\Swati\\AngularUK\\UdemyProj\\SendMailUtility1\\Template\\ContactUs.html";
            // ForgotPassword1 token = new ForgotPassword1();
            string body = File.ReadAllText(path);
            body = body.Replace("{RESET_PASSWORD_LINK}", "http://localhost:4200/reset-pwd");

            body = body.Replace("{CUSTOMER_ID}", contact.CustomerId.ToString());
            body = body.Replace("{CUSTOMER_NAME}", contact.Name);
            body = body.Replace("{MESSAGE}", contact.message);
            body = body.Replace("{EMAIL_ID}", contact.EmailId);

            MailMessage message = new MailMessage("bestbulliondeals@gmail.com", "swatiraykar448@gmail.com", "Nature Looks", body);
            message.IsBodyHtml = true;
            try
            {
                email.Send(message);
                //email.Send("swatiraykar448@gmail.com", recipients: EmailId, subject, body);

            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }


    }


}


