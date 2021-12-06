using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.SendEmailService
{
    public interface IEmailSender
    {
        string SendEmail(string from, string body);
    }
}
