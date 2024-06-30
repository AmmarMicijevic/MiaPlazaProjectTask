using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaPlazaProjectTask.Pages
{
    public class BasePage
    {
        private readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForElementToBeClickable(IWebElement element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Timeout (10 seconds) waiting for element to be clickable.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while waiting for element to be clickable: {ex.Message}");
            }
        }
    }
}
