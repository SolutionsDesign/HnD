/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
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
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using MailKit.Security;
using MarkdownDeep;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MimeKit;
using MimeKit.Text;
using SD.Tools.BCLExtensions.CollectionsRelated;

namespace SD.HnD.Utility
{
	/// <summary>
	/// General class for general utility routines. 
	/// </summary>
	public static class HnDGeneralUtils
	{
		/// <summary>
		/// Private constant for the maximum length for a generated password.
		/// </summary>
		private static readonly int GeneratedPasswordLength = 25;
		/// <summary>
		/// The length of the salt to use with every password hash.
		/// </summary>
		private static readonly int PasswordSaltLengthBytes = 32;
		/// <summary>
		/// The length of the pbkdf2 hash in bytes. 
		/// </summary>
		private static readonly int Pbkdf2HashLengthBytes = 32;
		/// <summary>
		/// The RNG to use for creating salts for passwords. 
		/// </summary>
		private static readonly RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();
		/// <summary>
		/// The default number of iterations to use for hashing a password. 
		/// </summary>
		private static readonly int Pbkdf2Iterations = 10000;


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
		/// Get the ip address passed in as string, which will remap the address to ip4 first. 
		/// </summary>
		/// <param name="remoteAddress"></param>
		/// <returns></returns>
		public static string GetRemoteIPAddressAsIP4String(IPAddress remoteAddress)
		{
			return remoteAddress == null ? "0.0.0.0" : remoteAddress.MapToIPv4().ToString();
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

			for(int i = 0, randomNr = 0; i < GeneratedPasswordLength; i++)
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
		/// Hashes the passed in string with a random salt using the Pbkdf2 hashing algorithm using HMAC SHA512. The salt is embedded
		/// into the result which is then Base64 encoded as a string. 
		/// </summary>
		/// <param name="password">The string to hash. If this string is already an MD5, basd64 encoded hash, set performPreMD5Hashing to false</param>
		/// <param name="performPreMD5Hashing">Old versions of HnD used MD5 hashed passwords and to migrate these to Pbkdf2 we rehashed the MD5Hashed variants.
		/// To signal the passed in password is already an MD5 base64 hash, this flag has to be false. If the password is the plain password as specified
		/// by the user, this flag has to be true. </param>
		/// <returns>the base64 encoded byte array which contains the salt and the hash and which is ready to be saved in the database</returns>
		public static string HashPassword(string password, bool performPreMD5Hashing)
		{
			var salt = new byte[PasswordSaltLengthBytes];
			_rng.GetBytes(salt);
			var resultAsByteArray = HnDGeneralUtils.PerformPbkdf2Hashing(password, salt, performPreMD5Hashing);
			return Convert.ToBase64String(resultAsByteArray);
		}


		/// <summary>
		/// Compares the passed in password with whether it's encoded in the passed in base64Hash. It does this by first decoding the base64 hash
		/// then obtaining the salt from that array, Pbkdf2 hashing the password specified with that salt and then comparing the bytes obtained with the 
		/// </summary>
		/// <param name="base64Hash">the base64 encoded byte array which contains the salt and the hash</param>
		/// <param name="password">The plain password to compare. This isn't an MD5 hashed variant, but a password specified by the user. </param>
		/// <returns></returns>
		public static bool ComparePbkdf2HashedPassword(string base64Hash, string password)
		{
			if(string.IsNullOrWhiteSpace(base64Hash))
			{
				return false;
			}

			if(string.IsNullOrEmpty(password))
			{
				return false;
			}

			byte[] base64HashAsByteArray = Convert.FromBase64String(base64Hash);
			if(base64HashAsByteArray.Length < (PasswordSaltLengthBytes + Pbkdf2HashLengthBytes))
			{
				// length of the byte array is wrong. 
				return false;
			}

			var salt = new byte[PasswordSaltLengthBytes];
			Array.Copy(base64HashAsByteArray, 0, salt, 0, PasswordSaltLengthBytes);

			// we have to prehash with MD5 as the password passed in is a plain text password.
			byte[] passwordPbkdf2Hashed = PerformPbkdf2Hashing(password, salt, performPreMD5Hashing: true);

			// now we compare the arrays. We can suffice with comparing the hashed bytes however.
			// base64HashAsBytes.Length is >= PasswordSaltLengthBytes, see above, so setting this to true is safe, it always iterates at least once.
			bool areEqual = true;
			for(int i = PasswordSaltLengthBytes; i < base64HashAsByteArray.Length; i++)
			{
				areEqual &= (passwordPbkdf2Hashed[i] == base64HashAsByteArray[i]);
				if(!areEqual)
				{
					break;
				}
			}

			return areEqual;
		}


		/// <summary>
		/// Sends the email specified to the addresses specified.
		/// </summary>
		/// <param name="subject">Subject.</param>
		/// <param name="message">Message.</param>
		/// <param name="fromAddress">From address.</param>
		/// <param name="toEmailAddresses">To email addresses.</param>
		/// <param name="emailData">The email data.</param>
		/// <returns>true if email sent, otherwise false</returns>
		public static async Task<bool> SendEmail(string subject, string message, string fromAddress, string[] toEmailAddresses, Dictionary<string, string> emailData)
		{
			string defaultToMailAddress = emailData.GetValue("defaultToEmailAddress") ?? String.Empty;
			var messageToSend = new MimeMessage();
			messageToSend.To.Add(new MailboxAddress(emailData.GetValue("siteName") ?? string.Empty, defaultToMailAddress));
			messageToSend.From.Add(new MailboxAddress(emailData.GetValue("siteName") ?? string.Empty, fromAddress));
			messageToSend.Subject = subject;
			messageToSend.Body = new TextPart(TextFormat.Plain) {Text = message};
			for(int i = 0; i < toEmailAddresses.Length; i++)
			{
				messageToSend.Bcc.Add(new MailboxAddress(string.Empty, toEmailAddresses[i]));
			}

			using(var smtpClient = new MailKit.Net.Smtp.SmtpClient())
			{
				smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
				bool useTls = XmlConvert.ToBoolean(emailData.GetValue("smtpEnableSsl"));
				var secureSocketOptions = useTls ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto;
				await smtpClient.ConnectAsync(emailData.GetValue("smtpHost"), int.Parse(emailData.GetValue("smtpPort")), secureSocketOptions).ConfigureAwait(false);
				await smtpClient.AuthenticateAsync(emailData.GetValue("smtpUserName"), emailData.GetValue("smtpPassword")).ConfigureAwait(false);
				await smtpClient.SendAsync(messageToSend).ConfigureAwait(false);
				await smtpClient.DisconnectAsync(true).ConfigureAwait(false);
			}

			return true;
		}


		/// <summary>
		/// Emails the given password to the given emailaddress. No username is specified.
		/// </summary>
		/// <param name="password">The password to email</param>
		/// <param name="emailAddress">The recipient's emailaddress.</param>
		/// <param name="emailData">The email data.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		public static async Task<bool> EmailPassword(string password, string emailAddress, Dictionary<string, string> emailData)
		{
			string emailTemplate = emailData.GetValue("emailTemplate") ?? string.Empty;
			var mailBody = StringBuilderCache.Acquire(emailTemplate.Length + 256);
			mailBody.Append(emailTemplate);
			string applicationURL = emailData.GetValue("applicationURL") ?? String.Empty;
			string siteName = emailData.GetValue("siteName") ?? String.Empty;
			if(!String.IsNullOrEmpty(emailTemplate))
			{
				// Use the existing template to format the body
				mailBody.Replace("[URL]", applicationURL);
				mailBody.Replace("[SiteName]", siteName);
				mailBody.Replace("[Password]", password);
			}

			// format the subject
			string subject = (emailData.GetValue("emailPasswordSubject") ?? String.Empty) + siteName;
			string fromAddress = emailData.GetValue("defaultFromEmailAddress") ?? String.Empty;
			return await SendEmail(subject, StringBuilderCache.GetStringAndRelease(mailBody), fromAddress, new[] {emailAddress}, emailData).ConfigureAwait(false);
		}


		/// <summary>
		/// Transforms the markdown specified into HTML using the markdowndeep parser (which has been adjusted for HnD).
		/// </summary>
		/// <param name="messageText">The message text.</param>
		/// <param name="emojiFilenamesPerName">the emojiname to filename mappings</param>
		/// <param name="smileyMappings">The shortcut to emoji mappings for the old smileys</param>
		/// <returns></returns>
		public static string TransformMarkdownToHtml(string messageText, Dictionary<string, string> emojiFilenamesPerName, Dictionary<string, string> smileyMappings)
		{
			if(String.IsNullOrWhiteSpace(messageText))
			{
				return String.Empty;
			}

			var md = new Markdown()
					 {
						 HnDMode = true,
						 SafeMode = true,
						 ExtraMode = true,
						 GitHubCodeBlocks = true,
						 MarkdownInHtml = false,
						 AutoHeadingIDs = false,
						 EmojiFilePerName = emojiFilenamesPerName,
						 EmojiPerSmileyShortcut = smileyMappings,
						 NoFollowLinks = true,
						 HtmlClassTitledImages = "figure",
					 };
			if(!messageText.EndsWith(Environment.NewLine))
			{
				messageText += Environment.NewLine;
			}

			return md.Transform(messageText);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="password">The string to hash. If this string is already an MD5, basd64 encoded hash, set performPreMD5Hashing to false</param>
		/// <param name="salt">the byte array with the rng produced salt to use for hashing the password specified</param>
		/// <param name="performPreMD5Hashing">Old versions of HnD used MD5 hashed passwords and to migrate these to Pbkdf2 we rehashed the MD5Hashed variants.
		///     To signal the passed in password is already an MD5 base64 hash, this flag has to be false. If the password is the plain password as specified
		///     by the user, this flag has to be true. </param>
		/// <returns>byte array with the salt in the lower indexes and the pbkdf2 hash bytes in the higher indexes</returns>
		private static byte[] PerformPbkdf2Hashing(string password, byte[] salt, bool performPreMD5Hashing)
		{
			// see if we need to pre-hash the passed in string. See note above.
			var passwordToHash = performPreMD5Hashing ? HnDGeneralUtils.CreateMD5HashedBase64String(password) : password;
			var prf = KeyDerivationPrf.HMACSHA512;
			byte[] hashedPassword = KeyDerivation.Pbkdf2(passwordToHash, salt, prf, Pbkdf2Iterations, Pbkdf2HashLengthBytes);

			// create a byte array with both the salt (in the lower indices) and the hashed result (higher indices) and base64 encode that as a single string. 
			// [<salt> (PasswordSaltLengthBytes in length) | <Pbkdf2 hashed pwd bytes> (Pbkdf2HashLengthBytes in length]
			var resultAsByteArray = new byte[PasswordSaltLengthBytes + Pbkdf2HashLengthBytes];
			Array.Copy(salt, 0, resultAsByteArray, 0, PasswordSaltLengthBytes);
			Array.Copy(hashedPassword, 0, resultAsByteArray, PasswordSaltLengthBytes, Pbkdf2HashLengthBytes);
			return resultAsByteArray;
		}


		/// <summary>
		/// Computes the MD5 hash value for the given string and converts the result into a Base64 encoded string.
		/// This string is directly comparable with and storable in the User table as a password.
		/// </summary>
		/// <param name="sToHash">String to hash and encode</param>
		/// <returns>MD5 hashed, Base64 encoded value of the given string</returns>
		private static string CreateMD5HashedBase64String(string sToHash)
		{
			// get generic MD5 hasher
			MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
			return Convert.ToBase64String(md5Hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(sToHash)));
		}
	}
}