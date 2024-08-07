﻿using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MiaPlazaProjectTask.Pages
{
    public class LandingPage
    {
        private readonly IWebDriver driver;

        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SearchBox => driver.FindElement(By.Id("search"));
        public IWebElement OnlineHighSchool => driver.FindElement(By.XPath("//span/a[contains(@href, 'miaprep.com/online-school')]"));

        /// <summary>
        /// Verifies that the title on the landing page matches the expected title "Miacademy - Engaging Online Curriculum".
        /// </summary>
        public void VerifyTitleOnLandingPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleIs("Miacademy - Engaging Online Curriculum"));
            Assert.That(driver.Title, Is.EqualTo("Miacademy - Engaging Online Curriculum"));
            Console.WriteLine("Title is : " + driver.Title);
        }

        /// <summary>
        /// Navigates to the Mia Prep Online High School page by clicking on the "Online High School" link and verifies the page title.
        /// </summary>
        public void NavigateToMiaPrepOnlineHighSchool()
        {
            Assert.That(OnlineHighSchool.Text, Is.EqualTo("Online High School"));
            OnlineHighSchool.Click();
        }
    }
}
