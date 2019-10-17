using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zimun_Torim
{
    class AppointmentsPageDoctorim
    {
        string doctorLastName = "";
        string doctorfirstName = "";
        string requestedDate = "";
        string appointmentFor = "";
        string requestedMonth = "";
        string requestedDay = "";

        public AppointmentsPageDoctorim(string DoctorLastName, string DoctorFirstName, string RequestedDate, string AppointmentFor)
        {
            doctorfirstName = DoctorFirstName;
            doctorLastName = DoctorLastName;
            requestedDate = RequestedDate;
            appointmentFor = AppointmentFor;
        }
        public void loginButton()
        {

            var buttonLogin = UnitTest1.wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("התחברות")));
            Thread.Sleep(4000);
            buttonLogin.Click();



        }
        public AppointmentsPageDoctorim(string RequestedMonth, string RequestedDay)
        {
            requestedDay = RequestedDay;
            requestedMonth = RequestedMonth;
        }
        public AppointmentsPageDoctorim()
        {
        }
        public void TypeDoctor()
        {
            var doctorNameElement = UnitTest1.wait.Until(x => x.FindElement(By.XPath("//input[@class='gui-input search__input JS-Autocomplete-Input JS-Focus JS-Placeholder-Input']")));
            doctorNameElement.Clear();
            doctorNameElement.SendKeys(doctorLastName + " " + doctorfirstName);
            doctorNameElement.SendKeys(Keys.Enter);
        }
        public void SearchForDoctor()
        {
            var SearchForDoctorButton = UnitTest1.wait.Until(x => x.FindElement(By.Name("doc_find_btn")));
            SearchForDoctorButton.Click();
        }
        public void setAppointmentForTheDcotror()
        {
            var doctorsLink = UnitTest1.wait.Until(x => x.FindElements(By.TagName("a")));
            for (int i = 0; i < doctorsLink.Count; i++)
            {
                if (doctorsLink[i].Text.ToString().Contains("קבע"))
                {
                    doctorsLink[i].Click();
                    break;
                }

            }

        }

        public void IsNewAppointmentAvailable()
        {
            var doctorsLink = UnitTest1.wait.Until(x => x.FindElements(By.XPath("//a[contains(@href, '38626')]")));
            for (int i = 0; i < doctorsLink.Count; i++)
            {
                if (doctorsLink[i].Text.ToString().Contains(UnitTest1._appointmentFor))
                {
                    doctorsLink[i].Click();
                    break;
                }

            }
        }
        public void ClickSetAppointmentButton()
        {
            var setAppointmentButton = UnitTest1.wait.Until(x => x.FindElement(By.CssSelector("#odoro>div>div>div>div>div.widget__container>div.output.clear>div.question>table>tbody>tr:nth-child(1)>td>a")));
            setAppointmentButton.Click();
        }
        public void ChooseMaccabi()
        {
            var chooseMaccabiButton = UnitTest1.wait.Until(x => x.FindElement(By.CssSelector("#odoro>div>div>div>div>div.widget__container>div.output.clear>div.question>table>tbody>tr:nth-child(1)>td")));
            chooseMaccabiButton.Click();
        }
        public void ChoosePregnantAppointment()
        {
            var choosePregnantAppointmentButton = UnitTest1.wait.Until(x => x.FindElement(By.CssSelector("#odoro>div>div>div>div>div.widget__container>div.output.clear>div>table>tbody>tr:nth-child(2)>td")));
            choosePregnantAppointmentButton.Click();
        }
        public void ContinueButton()
        {
            var continueButton = UnitTest1.wait.Until(x => x.FindElement(By.CssSelector("#odoro>div>div>div>div>div.widget__container>div.output.clear>div.question>table>tbody>tr>td")));
            continueButton.Click();
        }
    }
}
