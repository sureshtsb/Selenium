using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Linq;

namespace ConsoleApp1
{
internal class TimenMaterialPage
{
internal void ClickCreateNew(IWebDriver driver)
{

//Click create new button
driver.FindElement(By.XPath("//a[contains(.,'Create New')]")).Click();
}

internal void EnterValidDataandSave(IWebDriver driver, string code, string desc, string price)
{

//Enter code 
driver.FindElement(By.Id("Code")).SendKeys(code);

// Enterd description
driver.FindElement(By.Id("Description")).SendKeys(desc);

//Price per unit
driver.FindElement(By.XPath("//input[contains(@class,'k-formatted-value k-input')]")).SendKeys(price);

//click save
driver.FindElement(By.XPath("//input[@type='submit']")).Click();
}

internal void ValidateData(IWebDriver driver, string code, string desc, string price)
{

    //Verification part
    // assignment 3 is to verify that the time an material object that you created is displayed on the table
    try
    {

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
        IWebElement table = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table")));

        while(true)
        {
            var rows = table.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                var columns = row.FindElements(By.TagName("td")).ToList();
                if ((columns[0].Text == code) && (columns[2].Text == desc) && (columns[3].Text == price))
                {
                    Console.WriteLine("Test Passed, code found on table");
                    return;
                }
            }

            // Navigate to the next page until the next button is disabled
            if(!driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[3]")).GetAttribute("class").Contains("k-state-disabled"))
            {
                driver.FindElement(By.XPath("//span[contains(.,'Go to the next page')]")).Click();
            }
            else
            {
                Console.WriteLine("Test failed, " + code + " " + desc + " " + price + " not found in table");
                return;
            }

        };
    }
    catch(Exception e)
    {
        Console.WriteLine("Test Failed, Code not found" + e);
    }
}
}
}