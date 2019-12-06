using NUnit.Framework;
using OpenQA.Selenium;
using Rave.Test.SauceLab;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rave.Test.SauceLab.Pages
{
	internal class LoginPage : Base
	{
		public string Url
		{
			get { return ConfigurationManager.AppSettings["appUrl"].ToString(); }
		}

		public void Navigate()
		{
			Driver.Navigate().GoToUrl(Url);
		}

		[FindsBy(How = How.Id, Using = "mat-input-0")]
		private IWebElement EmailAddressField;

		[FindsBy(How = How.XPath, Using = "//div[@class='login-btn-grp']//input[contains(@class,'btn-danger')]")]
		private IWebElement LoginSubmitButton;

		[FindsBy(How = How.Id, Using = "mat-input-1")]
		private IWebElement PasswordField;

		public LoginPage()
		{
			PageFactory.InitElements(Driver, this);
		}

		public void ClickSubmitButton()
		{
			LoginSubmitButton.Click();
		}

		public void EnterEmailAddress(string emailAddress = "")
		{
			EmailAddressField.SendKeys(emailAddress);
		}

		public void EnterPassword(string password = "")
		{
			PasswordField.SendKeys(password);
		}

		public void Login(string emailAddress = "", string password = "")
		{
			EmailAddressField.Clear();
			EnterEmailAddress(emailAddress);
			PasswordField.Clear();
			EnterPassword(password);
		}
	}
}