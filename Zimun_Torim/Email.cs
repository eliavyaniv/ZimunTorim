using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zimun_Torim
{
    class Email
    {




        public static void SendReportEmail(string Subject, string To)
        {
            var application = new Application();
            var mail = (_MailItem)application.CreateItem(OlItemType.olMailItem);
            mail.Subject = Subject;
            mail.To = To;
            mail.Send();
        }
    }
}
