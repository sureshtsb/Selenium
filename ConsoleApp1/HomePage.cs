using System;
using OpenQA.Selenium;

namespace ConsoleApp1
{
    internal class HomePage
    {
        internal void VerifyHomePage(IWebDriver driver)
        {
            //assignment is to check whether hello hari is displayed on the page 
            IWebElement username = driver.FindElement(By.XPath("//a[contains(.,'Hello hari!')]"));
            Console.WriteLine("username.Text " + username.Text);

            if (username.Text == "Hello hari!")
                Console.WriteLine("verification passed - username displayed on home page");
            else
                Console.WriteLine("verification failed - username not displayed on home page ");
        }

        internal void ClickAdminstration(IWebDriver driver)
        {

            // assignment 2 admin > time n material > create new 

            //Click adminstration 
            driver.FindElement(By.XPath("//a[contains(.,'Administration')]")).Click();
        }

        internal void ClickTimenMaterial(IWebDriver driver)
        {
            //Click Time n Material 
            driver.FindElement(By.XPath("//a[contains(.,'Time & Materials')]")).Click();
        }
    }
}