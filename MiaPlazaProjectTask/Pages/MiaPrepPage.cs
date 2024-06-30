using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MiaPlazaProjectTask.Pages
{
    public class MiaPrepPage
    {
        private readonly IWebDriver driver;

        public MiaPrepPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ApplyToOurSchoolButton => driver.FindElement(By.XPath("//div[@class='wp-block-button']/a[contains(@href, 'forms.zohopublic.com')]"));

        public void VerifyTitleOnMiaPrepPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleIs("MiaPrep Online High School - MiaPrep"));
            Assert.That(driver.Title, Is.EqualTo("MiaPrep Online High School - MiaPrep"));
            Console.WriteLine("Title is : " + driver.Title);
        }

        public Boolean IsElementDisplayed()
        {
            if (ApplyToOurSchoolButton.Displayed)
            {
                Console.WriteLine("The element is displayed!");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClickOnTheApplyToOurSchoolButton()
        {
            ApplyToOurSchoolButton.Click();
            Console.WriteLine("The Apply to Our School button is clicked");
        }
    }
}
