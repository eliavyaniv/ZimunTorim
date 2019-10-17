using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zimun_Torim
{
    public class AppointmentsPage
    {
        string doctorLastName = "";
        string doctorfirstName = "";
        string requestedDate = "";
        public AppointmentsPage(string DoctorLastName, string DoctorFirstName, string RequestedDate)
        {
            doctorfirstName = DoctorFirstName;
            doctorLastName = DoctorLastName;
            requestedDate = RequestedDate;
        }

        public void SelectAppointmentsForDcotors()
        {
            Thread.Sleep(4000);
            var doctorsElementButton = UnitTest1.wait.Until(x => x.FindElements(By.CssSelector("a.btnM")));
            Thread.Sleep(4000);
            doctorsElementButton[1].Click();
        }

        public void EnterLastName()
        {
            var doctorLastNameElement = UnitTest1.wait.Until(x => x.FindElement(By.Id("ctl00_ctl00_MainPlaceHolder_Body_AppointmentOrderMainPageControl_1870_AppointmentOrderSearchArea_SearchArea_wcDoctorDetails_txtDoctorLastName")));
            doctorLastNameElement.SendKeys(doctorLastName);

        }
        public void EnterFirstName()
        {
            var doctorFirstNameElement = UnitTest1.wait.Until(x => x.FindElement(By.Id("ctl00_ctl00_MainPlaceHolder_Body_AppointmentOrderMainPageControl_1870_AppointmentOrderSearchArea_SearchArea_wcDoctorDetails_txtDoctorFirstName")));
            doctorFirstNameElement.SendKeys(doctorfirstName);
        }
        public void SearchForDoctorButton()
        {
            Thread.Sleep(2000);
            var SearchButtonElement = UnitTest1.wait.Until(x => x.FindElement(By.Id("lnkSearch")));
            SearchButtonElement.Click();

        }
        public void isDoctorCorrect()
        {
            var doctorsName = UnitTest1.wait.Until(x => x.FindElement(By.XPath("//*[@id='ctl01_doctorsGrid']/tbody/tr[2]/td[2]/a")));
            Thread.Sleep(2000);
            Assert.IsTrue((doctorsName.Text.ToString().Contains(doctorLastName)));

        }

        public DateTime isNextAvailableqeueAsRequested()
        {
            var nextAvailableQeue = UnitTest1.wait.Until(x => x.FindElement(By.XPath("//*[@id='ctl01_doctorsGrid']/tbody/tr[3]/td[4]")));
            Thread.Sleep(2000);
            Console.WriteLine("next available qeue:" + nextAvailableQeue.Text);

            var address = UnitTest1.wait.Until(x => x.FindElements(By.XPath("//*[@id='cliniclink']"))[1].Text);
            Console.WriteLine("address of doctor:" + address);

            var availabledateDateTime = Convert.ToDateTime(nextAvailableQeue.Text);
            var currentDateDateTime = Convert.ToDateTime(requestedDate);
            if (availabledateDateTime >= currentDateDateTime)
            {
                Assert.Fail("אין תאריך מוקדם יותר");
            }
            UnitTest1.dayToSelect = int.Parse(availabledateDateTime.Day.ToString());
            return availabledateDateTime;



        }


        public DateTime isNextAvailableqeueAsRequested1()
        {
            var nextAvailableQeue = UnitTest1.wait.Until(x => x.FindElement(By.XPath("//*[@id='ctl01_doctorsGrid']/tbody/tr[3]/td[4]")));
            Thread.Sleep(2000);

            var availabledateDateTime = Convert.ToDateTime(nextAvailableQeue.Text);
            var currentDateDateTime = Convert.ToDateTime(requestedDate);
            if (availabledateDateTime >= currentDateDateTime)
            {
                Assert.Fail("אין תאריך מוקדם יותר");
            }

            return availabledateDateTime;



        }
        public void setAppointment()
        {
            var setAppointmentbutton = UnitTest1.wait.Until(x => x.FindElement(By.CssSelector("#ctl01_doctorsGrid_ctl02_wcOrderQueue_divOrderQueue>a>span:nth-child(1)")));
            setAppointmentbutton.Click();
            Thread.Sleep(5000);
            var selectedDay = UnitTest1.wait.Until(x => x.FindElements(By.CssSelector(".selected-day")));
           for(int i=0;i<selectedDay.Count;i++)
            {
                var selectedDayText = selectedDay[i].FindElement(By.CssSelector("a.ui-state-default")).Text;
                if (int.Parse(selectedDayText)==UnitTest1.dayToSelect)
                {
                    selectedDay[i].Click();
                    break;
                }
            }
            Thread.Sleep(2500);
            try
            {
                var selectHour = UnitTest1.wait.Until(x => x.FindElement(By.CssSelector("div.hourRoller")));
                var selectHour2 = selectHour.FindElements(By.CssSelector("li.odoroHoursItem"));
                selectHour2[0].Click();
                
            }
            catch
            {
                var selectHour = UnitTest1.wait.Until(x => x.FindElement(By.CssSelector("div.hourRoller")));
                var selectHour2 = selectHour.FindElements(By.CssSelector("li.odoroHoursItem"));
            }
            var hamshechButton = UnitTest1.wait.Until(x => x.FindElement(By.CssSelector("a.btnM.float-left")));
            hamshechButton.Click();

            try
            {
                var IshurOShiuny = UnitTest1.wait.Until(x => x.FindElements(By.CssSelector("a.grayBtn")));
                IshurOShiuny[0].Click();//אישור
            }
            catch { }
        }

        public void setAppointment1(string ClickName, string ClickName2)
        {
           
            var setAppointmentbutton = UnitTest1.wait.Until(x => x.FindElement(By.CssSelector("#ctl01_doctorsGrid_ctl02_wcOrderQueue_divOrderQueue>a>span:nth-child(1)")));
            setAppointmentbutton.Click();
            Thread.Sleep(5000);
            var assignToClickName = UnitTest1.wait.Until(x => x.FindElement(By.XPath("//span[contains(.,'" + ClickName + "')]")));
            assignToClickName.Click();
            Thread.Sleep(3000);
            var table = UnitTest1.wait.Until(x => x.FindElements(By.TagName("table")));
            var trs = table[2].FindElements(By.TagName("tr"));
            var tds = trs[1].FindElements(By.TagName("td"));
            tds[4].Click();
            Thread.Sleep(2000);
            var assignToClickName2 = UnitTest1.wait.Until(x => x.FindElements(By.XPath("//span[contains(.,'" + ClickName2 + "')]")));
            assignToClickName2[1].Click();

        }

       

      

    }
}
