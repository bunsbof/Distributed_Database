using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiay.Utilities
{
	public class InputValidator
	{
		private StringBuilder errorBuilder = new StringBuilder();
		private string title = "Unknow field";
		private string rawString = "";
		public bool HasError => !string.IsNullOrWhiteSpace(errorBuilder.ToString());

		public InputValidator SetTitle(string errorTitle)
		{
			this.title = errorTitle;
			return this;
		}

		public InputValidator SetInputString(string inputString)
		{
			rawString = inputString;
			return this;
		}

		public string GetErrorMessage()
		{
			return errorBuilder.ToString();
		}

		public InputValidator SanitizeInput()
		{
			if (rawString.Length == 0)
				return this;

			string resultString = rawString[0].ToString();
			foreach (var letter in rawString.ToCharArray())
			{
				if (letter != ' ')
					resultString += letter.ToString();
				else
					if (resultString.Length > 0 && resultString[resultString.Length - 1] != ' ')
					resultString += letter.ToString();
			}

			rawString = resultString;

			return this;
		}

		public InputValidator Require()
		{
			if (rawString.Length == 0)
				errorBuilder.AppendLine(title + " Invalid");
			return this;
		}

		public InputValidator MustBeValidString()
		{
			string invalidChar = "~!@#$%^&*()+`-=,./<>?;':[]{}\\|";
			foreach (var symbol in invalidChar.ToCharArray())
			{
				if (rawString.Contains(symbol.ToString()))
				{
					errorBuilder.AppendLine(title + " can not contain invalid symbol");
					break;
				}
			}
			return this;
		}

		public InputValidator DoesNotContains(params char[] invalidLetters)
		{
			foreach (var symbol in invalidLetters)
			{
				if (rawString.Contains(symbol.ToString()))
				{
					errorBuilder.AppendLine(title + " can not contain invalid symbol: " + symbol.ToString());
					break;
				}
			}
			return this;
		}

		public InputValidator DoesNotContains(params string[] phrases)
		{
			foreach (var phrase in phrases)
			{
				if (rawString.ToLower().Contains(phrase.ToLower()))
				{
					errorBuilder.AppendLine(title + " can not contain invalid symbol: " + phrase);
					break;
				}
			}

			return this;
		}

		public InputValidator HasLengthEqualOrGreaterThan(int min)
		{
			if (rawString.Length < min)
				errorBuilder.AppendLine(title + " at least " + min + " symbol");
			return this;
		}

		public InputValidator HasLengthGreaterThan(int min)
		{
			if (rawString.Length <= min)
				errorBuilder.AppendLine(title + " at most " + min + "symbol");
			return this;
		}

		public InputValidator HasLengthEqualOrLessThan(int max)
		{
			if (rawString.Length > max)
				errorBuilder.AppendLine(title + " the less or equal " + max + " symbol");
			return this;
		}

		public InputValidator HasLengthLessThan(int max)
		{
			if (rawString.Length >= max)
				errorBuilder.AppendLine(title + " must less than " + max + " symbol");
			return this;
		}

		public InputValidator HasLengthEqualTo(int length)
		{
			if (rawString.Length != length)
				errorBuilder.AppendLine(title + " must have enough " + length + " symbol");
			return this;
		}

		public InputValidator IsNumber()
		{
			bool isDouble = double.TryParse(rawString, out _);
			if (!isDouble)
				errorBuilder.AppendLine(title
					+ " have to be a number");
			return this;
		}
	}
}
