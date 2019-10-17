using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Zimun_Torim
{
    class AvailableAppointmentsPage
    {
        string requestedDay = "";
        string requestedMonth = "";
        public AvailableAppointmentsPage(string RequestedMonth, [Optional] string RequestedDay)
        {
            requestedDay = RequestedDay;
            requestedMonth = RequestedMonth;
        }

        public void SendEmailOfNextAvailableAppointment()
        {
            var nextAvailableMonthElement = UnitTest1.wait.Until(x => x.FindElement(By.ClassName("mnmidle")).Text);
            var nextAvailableMonth = nextAvailableMonthElement.Substring(0, 2);

            var nextAvailableDayElement = UnitTest1.wait.Until(x => x.FindElements(By.ClassName("d-blank")));
            var nextavailday = nextAvailableDayElement[0].Text;

            if (nextAvailableMonth == requestedMonth)
            {
                string SubjectForEmail = "The next available appointment to Doron Kreizer is: " + nextavailday + "/" + nextAvailableMonth;
                Email.SendReportEmail(SubjectForEmail, "eliav.yaniv@gmail.com");
            }

            //if (nextAvailableMonth == requestedMonth && requestedDay==nextavailday)
            //{
            //    string SubjectForEmail = "The next available appointment to Doron Kreizer is: " + nextavailday + "/" + nextAvailableMonth;
            //    Email.SendReportEmail(SubjectForEmail, "hodana@gmail.com");
            //}
        }
    }
}
