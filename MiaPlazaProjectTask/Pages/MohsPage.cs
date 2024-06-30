using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace MiaPlazaProjectTask.Pages
{
    public class MohsPage
    {
        private readonly IWebDriver driver;


        public MohsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement FirstNameField => driver.FindElement(By.XPath("//input[@elname='First']"));
        private IWebElement LastNameField => driver.FindElement(By.XPath("//input[@elname='Last']"));
        private IWebElement EmailField => driver.FindElement(By.Id("Email-arialabel"));
        private IWebElement PhoneNumberField => driver.FindElement(By.XPath("//input[@name='PhoneNumber']"));
        private IWebElement SecondParentGuardianSelect => driver.FindElement(By.Id("select2-Dropdown-arialabel-container"));
        private IWebElement SearchEngineCheckbox => driver.FindElement(By.XPath("//label[./em[contains(text(), 'Search Engine')]]"));
        private IWebElement MiaPrepWebsiteCheckbox => driver.FindElement(By.XPath("//label[./em[contains(text(), 'MiaPrep website')]]"));
        private IWebElement MiacademyWebsiteCheckbox => driver.FindElement(By.XPath("//label[./em[contains(text(), 'Miacademy website')]]"));
        private IWebElement AlwaysIceCreamWebsiteCheckbox => driver.FindElement(By.XPath("//label[./em[contains(text(), 'Always-IceCream website')]]"));
        private IWebElement CleverDragonsWebsiteCheckbox => driver.FindElement(By.XPath("//label[./em[contains(text(), 'Clever-Dragons website')]]"));
        private IWebElement FacebookInstagramAdsCheckbox => driver.FindElement(By.XPath("//label[./em[contains(text(), 'Facebook/Instagram Ads')]]"));
        private IWebElement FacebookMohsPostGroupCheckbox => driver.FindElement(By.XPath("//label[./em[contains(text(), 'Facebook - MOHS Post/Group')]]"));
        private IWebElement FaebookGeneralHomeSchoolingCheckbox => driver.FindElement(By.XPath("//label[./em[contains(text(), 'Facebook - General')]]"));
        private IWebElement TikTokCheckbox => driver.FindElement(By.XPath("//label[./em[contains(text(), 'TikTok')]]"));
        private IWebElement OtherSocialMediaChecbox => driver.FindElement(By.XPath("//label[./em[contains(text(), 'Other social media')]]"));
        private IWebElement WordOfMouthCheckbox => driver.FindElement(By.XPath("//label[./em[contains(text(), 'Word of mouth')]]"));
        private IWebElement OtherCheckbox => driver.FindElement(By.XPath("//label[./em[text() = 'Other']]"));
        private IWebElement PreferredStartDateSelect => driver.FindElement(By.Id("Date-date"));
        private IWebElement NextButton => driver.FindElement(By.XPath("//button[contains(@aria-label, 'Next') and contains(@aria-label, 'Navigates to page 2 out of 3')]"));
        private IWebElement StudentInformationHeading => driver.FindElement(By.Id("Section3-li"));

        public void VerifyTitleOnMohsPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleIs("MOHS Initial Application"));
            Assert.That(driver.Title, Is.EqualTo("MOHS Initial Application"));
            Console.WriteLine("Title is : " + driver.Title);
        }

        public void VerifyAllElementsAreDisplayed()
        {
            // Wait for the SecondParentGuardianSelect element to be visible
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => SecondParentGuardianSelect.Displayed);
            List<IWebElement> elements = new List<IWebElement>
            {
                FirstNameField, LastNameField, EmailField, PhoneNumberField, SearchEngineCheckbox, MiaPrepWebsiteCheckbox, MiacademyWebsiteCheckbox, AlwaysIceCreamWebsiteCheckbox, CleverDragonsWebsiteCheckbox, FacebookInstagramAdsCheckbox, FacebookMohsPostGroupCheckbox, FaebookGeneralHomeSchoolingCheckbox, TikTokCheckbox, OtherSocialMediaChecbox, WordOfMouthCheckbox, OtherCheckbox, PreferredStartDateSelect, NextButton
            };
            foreach(var element in elements)
            {
                Assert.That(IsElementDisplayed(element), Is.True, $"{element.GetAttribute("name")} field is not displayed.");
            }
            
        }
        
        private bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                // Scroll the element into view
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                bool displayed = element.Displayed;
                Console.WriteLine($"Element displayed: {displayed}");
                return displayed;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Element not found: {ex.Message}");
                Assert.Fail( ex.Message );
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking element visibility: {ex.Message}");
                return false;
            }
        }

        private void PopulateFirstNameField()
        {
            string randomFirstName = RandomStringGenerator.GenerateRandomString(8);
            FirstNameField.SendKeys(randomFirstName);
            Console.WriteLine("Entered random first name: " + randomFirstName);
        }

        private void PopulateLastNameField()
        {
            string randomLastName = RandomStringGenerator.GenerateRandomString(13);
            LastNameField.SendKeys(randomLastName);
            Console.WriteLine("Entered random last name: " + randomLastName);
        }

        private void PopulateEmialField()
        {
            string email = RandomStringGenerator.GenerateRandomString(5);
            EmailField.SendKeys(email + "@gmail.com");
            Console.WriteLine("The email field is populated with: " + email + "@gmail.com");
        }

        private void PopulatePhoneField()
        {
            string phoneNumber = RandomStringGenerator.GenerateRandomNumericString(12);
            PhoneNumberField.SendKeys(phoneNumber);
            Console.WriteLine("Phone number field is populated with: " + phoneNumber);
        }

        private void ChooseInformationForSecondParent(string value)
        {
            SecondParentGuardianSelect.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//li[contains(@id, 'select2-Dropdown-arialabel-result') and contains(text(), '{value}')]")));
            IWebElement option = driver.FindElement(By.XPath($"//li[contains(@id, 'select2-Dropdown-arialabel-result') and contains(text(), '{value}')]"));
            option.Click();
            wait.Until(ExpectedConditions.TextToBePresentInElement(SecondParentGuardianSelect, value));
            Console.WriteLine($"Selected option: {value}");
        }

        private void SelectCheckbox(IWebElement checkbox)
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkbox);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(checkbox));

                checkbox.Click();
                Console.WriteLine($"Clicked on checkbox: " + checkbox.Text);
            }
            catch (ElementClickInterceptedException e)
            {
                Console.WriteLine($"Element click intercepted for checkbox with aria-label: {checkbox.Text}. Retrying with JavaScript click. Error: {e.Message}");
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkbox);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clicking checkbox: {ex.Message}");
            }
        }

        private void SelectElements()
        {
            SelectCheckbox(SearchEngineCheckbox);
            SelectCheckbox(CleverDragonsWebsiteCheckbox);
            SelectCheckbox(TikTokCheckbox);
            Console.WriteLine("The checkboxes are selected!");
        }

        private void EnterPreferredStartDate(int daysToAdd)
        {
            string futureDate = DateUtils.GetFutureDate(daysToAdd);
            PreferredStartDateSelect.SendKeys(futureDate);
            Console.WriteLine("The future date is entered: " + futureDate);
        }

        private void clickOnNextButton()
        {
            BasePage basePage = new BasePage(driver);
            basePage.WaitForElementToBeClickable(NextButton);
            NextButton.Click();
            Console.WriteLine("The next button is clicked");
        }

        public void populateAllRequiredFields()
        {
            PopulateFirstNameField();
            PopulateLastNameField();
            PopulateEmialField();
            PopulatePhoneField();
            ChooseInformationForSecondParent("No");
            SelectElements();
            EnterPreferredStartDate(15);
            clickOnNextButton();
        }

        public void ValidateStudentInformationPageIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => StudentInformationHeading.Displayed);
            Console.WriteLine("The Student Information page is displayed");
        }
    }
}
