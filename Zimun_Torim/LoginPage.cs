using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zimun_Torim
{
    class LoginPage
    {
        string userName = "";
        string password = "";
        public LoginPage(string Username, string Password)
        {
            userName = Username;
            password = Password;
        }

        public MainPage LoginToMaccabi()
        {
           // var form = UnitTest1.wait.Until(x => x.FindElement(By.CssSelector(".col.myID"))); 

           // var userNameElement = UnitTest1.wait.Until(x => x.FindElement(By.Id("identifyWithPasswordCitizenId")));

            

                var userNameElement = UnitTest1.wait.Until(x => x.FindElement(By.ClassName("fgid_262")));
            //userNameElement.SendKeys("036861672");
            //var passwordElement = UnitTest1.wait.Until(x => x.FindElement(By.Id("password")));
            var passwordElement = UnitTest1.wait.Until(x => x.FindElement(By.ClassName("fgid_342")));
            
            //var enterLoginButtonElement = UnitTest1.wait.Until(x => x.FindElement(By.CssSelector("button.submit.validatePassword")));
            var enterLoginButtonElement = UnitTest1.wait.Until(x => x.FindElement(By.ClassName("fgid_376")));
            userNameElement.SendKeys(userName);
            passwordElement.SendKeys(password);
            enterLoginButtonElement.Click();
            return new MainPage();
        }
        public AppointmentsPageDoctorim LoginToDoctorim()
        {
            var userNameElement = UnitTest1.wait.Until(x => x.FindElement(By.Name("email2")));
            var passwordElement = UnitTest1.wait.Until(x => x.FindElement(By.Name("pw3")));


            var enterLoginButtonElement = UnitTest1.wait.Until(x => x.FindElement(By.XPath("//button[@type='submit']")));
            userNameElement.SendKeys(userName);
            passwordElement.SendKeys(password);
            enterLoginButtonElement.Click();
            Thread.Sleep(1000);
            return new AppointmentsPageDoctorim();
        }
    }
}
