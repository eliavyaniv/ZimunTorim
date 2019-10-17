using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zimun_Torim
{
    public class MainPage
    {
        public MainPage()
        {

        }

        public void EnterNewAssignment()
        {
            Thread.Sleep(3000);
            var newAppointment = UnitTest1.wait.Until(x => x.FindElement(By.Id("ctl00_ctl00_MainPlaceHolder_Body_wcHomeUserPersonalNavMenu_rptUserPersonalMenu_ctl00_lnkCatData")));
            newAppointment.Click();

        }
    }
}
