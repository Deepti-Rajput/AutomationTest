using OpenQA.Selenium;
using Rave.Test.SauceLab;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rave.Test.SauceLab.Pages
{
	public class ProfilePage : Base
	{
		[FindsBy(How = How.CssSelector, Using = ".name-title .ng-star-inserted")]
		private IWebElement UsernameLabel;

		public ProfilePage()
		{
			PageFactory.InitElements(Driver, this);
		}

		public string GetUserName()
		{
			Thread.Sleep(10000);
			return UsernameLabel.Text;
		}
	}
}