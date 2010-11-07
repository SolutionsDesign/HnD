/*
	This file is part of HnD.
	HnD is (c) 2002-2007 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Net;

namespace SD.HnD.Utility
{
	/// <summary>
	/// General class for general utility routines. 
	/// </summary>
	public class GeneralUtils
	{
		/// <summary>
		/// Private constant for the maximum length for a generated password.
		/// </summary>
		private static readonly int GeneratedPasswordLength = 10;


		/// <summary>
		/// Tries the value to convert to int. If convert fails due to an exception, 0 is returned.
		/// </summary>
		/// <param name="toConvert">To convert.</param>
		/// <returns>int value which is represented by the string representation toConvert, or 0 if conversion failed</returns>
		public static int TryConvertToInt(string toConvert)
		{
			int toReturn = 0;
			if(!Int32.TryParse(toConvert, out toReturn))
			{
				toReturn = 0;
			}
			return toReturn;
		}


		/// <summary>
		/// Tries the value to convert to short. If convert fails due to an exception, 0 is returned.
		/// </summary>
		/// <param name="toConvert">To convert.</param>
		/// <returns>short value which is represented by the string representation toConvert, or 0 if conversion failed</returns>
		public static short TryConvertToShort(string toConvert)
		{
			short toReturn = 0;
			if(!Int16.TryParse(toConvert, out toReturn))
			{
				toReturn = 0;
			}
			return toReturn;
		}
		
		
		/// <summary>
		/// Generates a random password string. The password generated contains solely readable
		/// characters available on every keyboard.
		/// </summary>
		/// <returns>a password string, generated using a randomizer.</returns>
		public static string GenerateRandomPassword()
		{
			StringBuilder newPassword = new StringBuilder(GeneratedPasswordLength);
			
			// create randomizer object
			Random rand = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);
			
			for(int i = 0, randomNr=0;i < GeneratedPasswordLength; i++)
			{
				bool isValid = false;
				while(!isValid)
				{
					randomNr = rand.Next(33, 126);
					isValid = (randomNr > 47 && randomNr < 58) || (randomNr > 64 && randomNr < 91) ||
								(randomNr > 96 && randomNr < 123);
				}
				newPassword.Append(Convert.ToChar(randomNr));
			}
			return newPassword.ToString();
		}


		/// <summary>
		/// Computes the MD5 hash value for the given string and converts the result into a Base64 encoded string.
		/// This string is directly comparable with and storable in the User table as a password.
		/// </summary>
		/// <param name="sToHash">String to hash and encode</param>
		/// <returns>MD5 hashed, Base64 encoded value of the given string</returns>
		public static string CreateMD5HashedBase64String(string sToHash)
		{
			// get generic MD5 hasher
			MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
			return Convert.ToBase64String(md5Hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(sToHash)));
		}


		/// <summary>
		/// Sends the email specified to the addresses specified.
		/// </summary>
		/// <param name="subject">Subject.</param>
		/// <param name="message">Message.</param>
		/// <param name="fromAddress">From address.</param>
		/// <param name="toEmailAddresses">To email addresses.</param>
		/// <param name="emailData">The email data.</param>
		/// <param name="sendAsynchronically">if set to true, the email will be send asynchronically otherwise synchronically</param>
		/// <returns>true if email sent, otherwise false</returns>
		public static bool SendEmail(string subject, string message, string fromAddress, string[] toEmailAddresses, 
				Dictionary<string, string> emailData, bool sendAsynchronically)
		{
			string defaultToMailAddress = string.Empty;
			emailData.TryGetValue("defaultToEmailAddress", out defaultToMailAddress);

			MailMessage messageToSend = new MailMessage(fromAddress, defaultToMailAddress);
			messageToSend.Subject=subject;
			messageToSend.Body = message;
			for(int i = 0; i < toEmailAddresses.Length; i++)
			{
				messageToSend.Bcc.Add(new MailAddress(toEmailAddresses[i]));
			}
			messageToSend.IsBodyHtml = false;

			// host and smtp credentials are set in .config file
			SmtpClient client = new SmtpClient();
			if(sendAsynchronically)
			{
				// send email asynchronously.
				client.SendAsync(messageToSend, null);
			}
			else
			{
				client.Send(messageToSend);
			}
			return true;
		}


		/// <summary>
		/// Emails the given password to the given emailaddress. No username is specified.
		/// </summary>
		/// <param name="password">The password to email</param>
		/// <param name="emailAddress">The recipient's emailaddress.</param>
		/// <param name="emailTemplate">The email template.</param>
		/// <param name="emailData">The email data.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static bool EmailPassword(string password, string emailAddress, string emailTemplate, Dictionary<string, string> emailData)
		{
			StringBuilder mailBody = new StringBuilder(emailTemplate);

			string applicationURL = string.Empty;
			emailData.TryGetValue("applicationURL", out applicationURL);

			if (!string.IsNullOrEmpty(emailTemplate))
			{
				// Use the existing template to format the body
				string siteName = string.Empty;
				emailData.TryGetValue("siteName", out siteName);

				mailBody.Replace("[URL]", applicationURL);
				mailBody.Replace("[SiteName]", siteName);
				mailBody.Replace("[Password]", password);
			}

			// format the subject
			string subject = string.Empty;
			emailData.TryGetValue("emailPasswordSubject", out subject);
			subject += applicationURL;

			string fromAddress = string.Empty;
			emailData.TryGetValue("defaultFromEmailAddress", out fromAddress);

			// send it
			// host and smtp credentials are set in .config file
			SmtpClient client = new SmtpClient();
			client.Send(fromAddress, emailAddress, subject, mailBody.ToString());
			return true;
		}

	}
}
