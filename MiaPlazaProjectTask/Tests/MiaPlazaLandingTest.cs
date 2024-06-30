using NUnit.Framework;
using MiaPlazaProjectTask.BaseClass;

namespace MiaPlazaProjectTask.Tests
{
    [TestFixture]
    public class MiaPlazaLandingTest : BaseTest
    {
        [Test]
        public void PractialTask()
        {
            landingPage.VerifyTitleOnLandingPage();
            landingPage.NavigateToMiaPrepOnlineHighSchool();
            miaPrepPage.VerifyTitleOnMiaPrepPage();
            miaPrepPage.IsElementDisplayed();
            miaPrepPage.ClickOnTheApplyToOurSchoolButton();
            mohsPage.VerifyTitleOnMohsPage();
            mohsPage.VerifyAllElementsAreDisplayed();
            mohsPage.PopulateAllRequiredFields("No", 6);
            mohsPage.ValidateStudentInformationPageIsDisplayed();
        }
    }
}
