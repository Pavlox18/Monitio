using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System;

namespace Monitio.Common
{
	public class PasswordManager
	{
		public static string GenerateHashFromString(string password)
		{
			string hashString = string.Empty;
			using (var SHA512 = new SHA512CryptoServiceProvider())
			{
				byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
				byte[] hashBytes = SHA512.ComputeHash(passwordBytes);
				hashString = BitConverter.ToString(hashBytes).Replace("-", "");
			}

			return hashString;
		}

		public static bool IsPasswordValid(string passwordString, string hashString)
		{
			bool result = false;
			using (var SHA512 = new SHA512CryptoServiceProvider())
			{
				byte[] hashBytes = Encoding.UTF8.GetBytes(hashString);
				byte[] passwordHashBytes = Encoding.UTF8.GetBytes(GenerateHashFromString(passwordString));
				result = StructuralComparisons.StructuralEqualityComparer.Equals(passwordHashBytes, hashBytes);
			}
			return result;
		}
	}
}
