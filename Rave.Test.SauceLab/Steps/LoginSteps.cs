using NUnit.Framework;
using Rave.Test.SauceLab;
using Rave.Test.SauceLab.Pages;
using System;
using TechTalk.SpecFlow;

namespace Rave.Test.SauceLab.Steps
{
	[Binding]
	public class LoginSteps : Base
	{
		private LoginPage loginPage;

		[BeforeTestRun]
		public static void BeforeTestRun()
		{
			StartBrowser();
		}

		[AfterTestRun]
		public static void AfterTestRun()
		{
			CloseDriver();
		}

		[TearDown]
		public static void TearDown()
		{
			CloseDriver();
		}

		[Given(@"I am at login page of application")]
		public void GivenIAmAtLoginPageOfApplication()
		{
			loginPage = new LoginPage();
			loginPage.Navigate();
		}

		[When(@"I enter username ""(.*)"" and passowrd ""(.*)""")]
		public void WhenIEnterUsernameAndPassowrd(string userName, string password)
		{
			loginPage.Login(userName, password);
		}

		[When(@"I click on login button")]
		public void WhenIClickOnLoginButton()
		{
			loginPage.ClickSubmitButton();
		}

		[Then(@"the correct username ""(.*)"" should be displayed")]
		public void ThenTheCorrectUsernameShouldBeDisplayed(string userName)
		{
			var profilePage = new ProfilePage();
			//Assert to check condition
			Assert.AreEqual(profilePage.GetUserName(), userName);
		}
	}
}