using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Monitio.Common.Tests
{
	[TestClass]
	public class PasswordManagerTests
	{
		[TestMethod]
		public void TestIsPasswordValid()
		{
			string testPassword = "testpassword123!@#";
			string hashString = "8B700C251BD94B25C0576BD40B59F1B12396743CDA442F2355A4A25D3BDADDE8F48BEC84C1158C4571A72B3001B8539E63F75BCFFC2291BCF9B01B0778432AB3";

			Assert.IsTrue(PasswordManager.IsPasswordValid(testPassword, hashString));
		}

		[TestMethod]
		public void TestIsPasswordValidWithInvalidPassword()
		{
			string testPassword = "testpassword123!@#1";
			string hashString = "8B700C251BD94B25C0576BD40B59F1B12396743CDA442F2355A4A25D3BDADDE8F48BEC84C1158C4571A72B3001B8539E63F75BCFFC2291BCF9B01B0778432AB3";

			Assert.IsFalse(PasswordManager.IsPasswordValid(testPassword, hashString));
		}

		[TestMethod]
		public void TestPasswordGeneration()
		{
			string testPassword = "testpassword123!@#";
			string hashString = "8B700C251BD94B25C0576BD40B59F1B12396743CDA442F2355A4A25D3BDADDE8F48BEC84C1158C4571A72B3001B8539E63F75BCFFC2291BCF9B01B0778432AB3";
			string generatedHash = PasswordManager.GenerateHashFromString(testPassword);
			Assert.IsTrue(generatedHash == hashString);
		}
	}
}
