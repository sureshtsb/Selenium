using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Browser initiate 
            IWebDriver driver = new ChromeDriver();

            //navigate to horse-dev
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            //maximize t
            driver.Manage().Window.Maximize();

            //access loginsucess method 
            
            // an instance of class
            LoginPage loginInstance = new LoginPage();
            loginInstance.LoginSuccess(driver);

            //Class for Home page,
            // method to verify the home 
            // method to click adminstration
            // method to click time n material

            HomePage homeInstance = new HomePage();
            homeInstance.VerifyHomePage(driver);
            homeInstance.ClickAdminstration(driver);
            homeInstance.ClickTimenMaterial(driver);


            TimenMaterialPage tmPage = new TimenMaterialPage();
            tmPage.ClickCreateNew(driver);
            string code = "ICAug19";
            string description = "Selenium Training";
            string price = "$155.00";

            tmPage.EnterValidDataandSave(driver, code, description, price);
            tmPage.ValidateData(driver, code, description, price);

            // to stop console from closing. 
            Console.ReadLine();

            //Close the driver
            driver.Quit();

            //static class 
            //StaticClass.StaticMethod(); 
            //comment a line ctrl +k + c
            //uncomment a line ctrl +k + u

        }
    }
}
