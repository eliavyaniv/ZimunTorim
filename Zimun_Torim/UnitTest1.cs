using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace Zimun_Torim
{
    [TestFixture]
    public class UnitTest1
    {
        //test
        public static int dayToSelect = 0;
        public static IWebDriver driver;
        public static WebDriverWait wait;
        public static string _appointmentFor = "";
       
        [SetUp]
        public void Init()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            //driver.Manage().Window.Maximize();


            wait = new WebDriverWait(UnitTest1.driver, new TimeSpan(0, 0, 40));


        }
        [TearDown]
        public void teardown()
        {
            Thread.Sleep(4000);
            driver.Quit();
        }
        
        [TestCase("036861672", "punchi1", "פורת", "משה", "23/05/2019")]
        public void IsDoctorAvailableYaniv(string userName, string password, string doctorLastName, string doctorFirstName, string currentDateDateTime)
        {
           
            driver.Navigate().GoToUrl("https://online.maccabi4u.co.il/dana-na/auth/url_44/welcome.cgi");

            var Login = new LoginPage(userName, password);
            var MainPage = Login.LoginToMaccabi();
            MainPage.EnterNewAssignment();
            var AppointmentsPage = new AppointmentsPage(DoctorLastName: doctorLastName, DoctorFirstName: doctorFirstName, RequestedDate: currentDateDateTime);
            AppointmentsPage.SelectAppointmentsForDcotors();
            Thread.Sleep(2000);
            AppointmentsPage.EnterLastName();
            Thread.Sleep(2000);
            AppointmentsPage.EnterFirstName();
            Thread.Sleep(2000);
            AppointmentsPage.SearchForDoctorButton();
            Thread.Sleep(2000);
            AppointmentsPage.isDoctorCorrect();
            Thread.Sleep(2000);
            DateTime mytordate = AppointmentsPage.isNextAvailableqeueAsRequested();
            Thread.Sleep(2000);
            Email.SendReportEmail(mytordate + " :יש תור  בתאריך  מוקדם יותר", "eliav.yaniv@gmail.com");
            Thread.Sleep(2000);
            //AppointmentsPage.setAppointment();


        }
       //[Ignore("")]
        [TestCase("029386141", "bjni1234", "עצמון", "יובל", "20/05/2019")]
        public void IsDoctorAvailableOded(string userName, string password, string doctorLastName, string doctorFirstName, string currentDateDateTime)
        {
            driver.Navigate().GoToUrl("https://online.maccabi4u.co.il/dana-na/auth/url_44/welcome.cgi");
            Thread.Sleep(2000);
            var Login = new LoginPage(userName, password);
            var MainPage = Login.LoginToMaccabi();
            MainPage.EnterNewAssignment();
            var AppointmentsPage = new AppointmentsPage(DoctorLastName: doctorLastName, DoctorFirstName: doctorFirstName, RequestedDate: currentDateDateTime);
            AppointmentsPage.SelectAppointmentsForDcotors();
            Thread.Sleep(2000);
            AppointmentsPage.EnterLastName();
            Thread.Sleep(2000);
            AppointmentsPage.EnterFirstName();
            Thread.Sleep(2000);
            AppointmentsPage.SearchForDoctorButton();
            Thread.Sleep(2000);
            AppointmentsPage.isDoctorCorrect();
            Thread.Sleep(2000);
            DateTime mytordate = AppointmentsPage.isNextAvailableqeueAsRequested();
            Thread.Sleep(2000);
            Email.SendReportEmail(mytordate + " :יש תור  בתאריך  מוקדם יותר", "Avitallevi20@gmail.com");
            Thread.Sleep(2000);
           // AppointmentsPage.setAppointment1("הצג תורים פנויים","אישור");


        }


        [Ignore("")]
        [TestCase("eliav.yaniv@gmail.com", "punchi1", "קרייזר", "דורון", "03", "יניב", "25")]
        public void IsDoctorAvailableDoctorim(string userName, string password, string doctorLastName, string doctorFirstName, string nextRequestedMonth, string appointmentFor, string nextRequestedDay)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.doctorim.co.il");
            
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl("https://www.doctorim.co.il/login.php");
            _appointmentFor = appointmentFor;
            var searchDoctor = new AppointmentsPageDoctorim(doctorLastName, doctorFirstName, nextRequestedMonth, appointmentFor);
            searchDoctor.loginButton();

            var login = new LoginPage(userName, password);
            var IsAppointmentAvailable = login.LoginToDoctorim();



            searchDoctor.TypeDoctor();
            Thread.Sleep(4000);
            //  searchDoctor.SearchForDoctor();
            switchToNewWindow();
            searchDoctor.setAppointmentForTheDcotror();
            switchToNewWindow();

            IsAppointmentAvailable.IsNewAppointmentAvailable();
            Thread.Sleep(500);
            IsAppointmentAvailable.ClickSetAppointmentButton();
            Thread.Sleep(500);
            IsAppointmentAvailable.ChooseMaccabi();
            Thread.Sleep(500);
            IsAppointmentAvailable.ChoosePregnantAppointment();
            Thread.Sleep(500);
            IsAppointmentAvailable.ContinueButton();
            Thread.Sleep(500);
            var NextAvailableDate = new AvailableAppointmentsPage(nextRequestedMonth);
            NextAvailableDate.SendEmailOfNextAvailableAppointment();


        }

     

        public static void switchToNewWindow()
        {
            string currentTab = driver.CurrentWindowHandle;
            foreach (string tab in driver.WindowHandles)
            {
                if (!tab.Equals(currentTab))
                {
                    driver.SwitchTo().Window(tab);
                }
            }
        }
    }
}
