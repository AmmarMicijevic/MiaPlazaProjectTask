using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MiaPlazaProjectTask.Pages;

namespace MiaPlazaProjectTask.BaseClass
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LandingPage landingPage;
        protected MiaPrepPage miaPrepPage;
        protected MohsPage mohsPage;
        protected RandomStringGenerator randomStringGenerator;
        protected DateUtils dateUtils;
        protected BasePage basePage;

        public BaseTest()
        {
            Initialize();
        }

        private void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://miacademy.co/#/";

            // Initialize page objects
            landingPage = new LandingPage(driver);
            miaPrepPage = new MiaPrepPage(driver);
            mohsPage = new MohsPage(driver);
            randomStringGenerator = new RandomStringGenerator();
            dateUtils = new DateUtils();
            basePage = new BasePage(driver);
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
