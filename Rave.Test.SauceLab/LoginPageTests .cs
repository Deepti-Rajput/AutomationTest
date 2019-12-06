using NUnit.Framework;
using Rave.Test.SauceLab.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rave.Test.SauceLab
{
	[TestFixture]
	public class Class1 : Base
	{
		[Test]
		public void LoginAsAnExisingUser()
		{
			var loginPage = new LoginPage();
			loginPage.Navigate();
			loginPage.Login("9819606607", "1234");
			loginPage.ClickSubmitButton();
			var profilePage = new ProfilePage();
			//Assert to check condition
			Assert.AreEqual(profilePage.GetUserName(), "Rahul Sonawane (Rave_QA)");
		}

		[SetUp]
		public static void BeforeTestRun()
		{
			StartBrowser();
		}

		[TearDown]
		public static void AfterTestRun()
		{
			CloseDriver();
		}
	}
}