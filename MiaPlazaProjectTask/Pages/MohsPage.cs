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
        private readonly Random random = new Random();


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

        /// <summary>
        /// Verifies that the title of the page matches the expected title for MOHS Initial Application.
        /// Waits up to 10 seconds for the title to match before asserting.
        /// </summary>
        public void VerifyTitleOnMohsPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleIs("MOHS Initial Application"));
            Assert.That(driver.Title, Is.EqualTo("MOHS Initial Application"));
            Console.WriteLine("Title is : " + driver.Title);
        }


        /// <summary>
        /// Verifies that all elements on the page are displayed.
        /// Throws an assertion error if any element is not displayed.
        /// </summary>
        public void VerifyAllElementsAreDisplayed()
        {
            // Wait for the SecondParentGuardianSelect element to be visible
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => SecondParentGuardianSelect.Displayed);
            List<IWebElement> elements = new List<IWebElement>
            {
                FirstNameField, LastNameField, EmailField, PhoneNumberField, SearchEngineCheckbox, MiaPrepWebsiteCheckbox, MiacademyWebsiteCheckbox, AlwaysIceCreamWebsiteCheckbox, CleverDragonsWebsiteCheckbox, FacebookInstagramAdsCheckbox, FacebookMohsPostGroupCheckbox, FaebookGeneralHomeSchoolingCheckbox, TikTokCheckbox, OtherSocialMediaChecbox, WordOfMouthCheckbox, OtherCheckbox, PreferredStartDateSelect, NextButton
            };
            foreach (var element in elements)
            {
                Assert.That(IsElementDisplayed(element), Is.True, $"{element.GetAttribute("name")} field is not displayed.");
            }
        }

        /// <summary>
        /// Checks if an element is displayed on the page.
        /// Scrolls the element into view and returns true if displayed, false otherwise.
        /// </summary>
        /// <param name="element">The WebElement to check.</param>
        /// <returns>True if the element is displayed, false otherwise.</returns>
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
                Assert.Fail(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking element visibility: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Populates the first name field with a randomly generated string.
        /// </summary>
        private void PopulateFirstNameField()
        {
            string randomFirstName = RandomStringGenerator.GenerateRandomString(8);
            FirstNameField.SendKeys(randomFirstName);
            Console.WriteLine("Entered random first name: " + randomFirstName);
        }

        /// <summary>
        /// Populates the last name field with a randomly generated string.
        /// </summary>
        private void PopulateLastNameField()
        {
            string randomLastName = RandomStringGenerator.GenerateRandomString(13);
            LastNameField.SendKeys(randomLastName);
            Console.WriteLine("Entered random last name: " + randomLastName);
        }

        /// <summary>
        /// Populates the email field with a randomly generated email address.
        /// </summary>
        private void PopulateEmialField()
        {
            string email = RandomStringGenerator.GenerateRandomString(5);
            EmailField.SendKeys(email + "@gmail.com");
            Console.WriteLine("The email field is populated with: " + email + "@gmail.com");
        }

        /// <summary>
        /// Populates the phone number field with a randomly generated numeric string.
        /// </summary>
        private void PopulatePhoneField()
        {
            string phoneNumber = RandomStringGenerator.GenerateRandomNumericString(12);
            PhoneNumberField.SendKeys(phoneNumber);
            Console.WriteLine("Phone number field is populated with: " + phoneNumber);
        }

        /// <summary>
        /// Chooses the option for the second parent or guardian from a dropdown list.
        /// Options: Yes or No
        /// </summary>
        /// <param name="value">The value of the option to be selected.</param>
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

        /// <summary>
        /// Selects a checkbox element, scrolling it into view if necessary, and handles click operations.
        /// </summary>
        /// <param name="checkbox">The checkbox element to be selected.</param>
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

        /// <summary>
        /// Enters a preferred start date into the PreferredStartDateSelect field.
        /// </summary>
        /// <param name="daysToAdd">Number of days to add to the current date.</param>
        private void EnterPreferredStartDate(int daysToAdd)
        {
            string futureDate = DateUtils.GetFutureDate(daysToAdd);
            PreferredStartDateSelect.SendKeys(futureDate);
            Console.WriteLine("The future date is entered: " + futureDate);
        }

        /// <summary>
        /// Clicks on the NextButton after ensuring it is clickable.
        /// </summary>
        private void ClickOnNextButton()
        {
            BasePage basePage = new BasePage(driver);
            basePage.WaitForElementToBeClickable(NextButton);
            NextButton.Click();
            Console.WriteLine("The next button is clicked");
        }

        /// <summary>
        /// Populates all required fields on the page including first name, last name, email, phone number,
        /// second parent information, checkboxes, preferred start date, and clicks on the Next button.
        /// </summary>
        public void PopulateAllRequiredFields(string secondParent, int chechboxNumber)
        {
            PopulateFirstNameField();
            PopulateLastNameField();
            PopulateEmialField();
            PopulatePhoneField();
            ChooseInformationForSecondParent(secondParent);
            SelectRandomlyOptionsForHowDidYouHearAboutUs(chechboxNumber);
            EnterPreferredStartDate(15);
            ClickOnNextButton();
        }

        /// <summary>
        /// Validates that the Student Information page is displayed by waiting for the StudentInformationHeading
        /// element to be visible.
        /// </summary>
        public void ValidateStudentInformationPageIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => StudentInformationHeading.Displayed);
            Console.WriteLine("The Student Information page is displayed");
        }

        /// <summary>
        /// Selects a specified number of checkboxes randomly from a given list of checkbox elements.
        /// </summary>
        /// <param name="numberOfSelections">The number of checkboxes to select.</param>
        private void SelectRandomlyOptionsForHowDidYouHearAboutUs(int numberOfSelections)
        {
            var checkboxElements = driver.FindElements(By.XPath("//li[@id = 'Checkbox-li']//input[contains(@id, 'Checkbox')]"));

            if (numberOfSelections > checkboxElements.Count)
            {
                throw new ArgumentException("Number of selections exceeds the total number of checkboxes.");
            }

            List<IWebElement> checkboxList = new List<IWebElement>(checkboxElements);
            Shuffle(checkboxList);

            int selectedCount = 0;

            foreach (var checkbox in checkboxList)
            {
                if (selectedCount >= numberOfSelections)
                {
                    break;
                }

                if (!checkbox.Selected)
                {
                    try
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkbox);
                        bool clicked = SelectRandomlyCheckboxes(checkbox);
                        if (clicked)
                        {
                            selectedCount++;
                            Console.WriteLine($"Selected checkbox: {checkbox.GetAttribute("value")}");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to select checkbox: {checkbox.GetAttribute("value")}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing checkbox: {ex.Message}");
                    }
                }
            }
            if (selectedCount < numberOfSelections)
            {
                throw new Exception($"Could only select {selectedCount} checkboxes out of the requested {numberOfSelections}.");
            }
        }

        /// <summary>
        /// Clicks the checkbox using JavaScript and waits for it to be selected.
        /// </summary>
        /// <param name="checkbox">The checkbox element to be clicked.</param>
        /// <returns>True if the checkbox was successfully clicked and selected, otherwise false.</returns>
        private bool SelectRandomlyCheckboxes(IWebElement checkbox)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkbox);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => checkbox.Selected);
            bool clicked = checkbox.Selected;
            return clicked;
        }

        /// <summary>
        /// Shuffles a list of elements randomly.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to shuffle.</param>
        private void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
