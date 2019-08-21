using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LoginPage
    {

        //Blog about different access specifiers in c#
        internal void LoginSuccess(IWebDriver driver)
        {
            // Identfying the username 
            IWebElement firstName = driver.FindElement(By.Id("UserName"));
            firstName.SendKeys("hari");

            //Identify password 
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            // Identify Login and click
            IWebElement loginbtn = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginbtn.Click();
        }
    }
}
