using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexUnicode
{
	public static class Program
	{
		public static void Main() {
			const string content = @"Emails addresses
* test1@domain.com
* test2@domain.com";
			var unicodeContent = new StreamReader(new MemoryStream(Encoding.Unicode.GetBytes(content))).ReadToEnd();

			PrintResults(content, "unencoded input");
			PrintResults(unicodeContent, "input encoded as unicode");
		}

		private static void PrintResults(string content, string label) {
			Console.WriteLine($"Running test using {label}");
			var regex = new Regex(@"\b[\w\.=-]+@[\w\.-]+\.[\w]{2,3}\b", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

			var match = regex.Match(content);
			if (!match.Success) {
				Console.WriteLine("No results found");
			} else {
				while (match.Success) {
					Console.WriteLine(match.Value);
					match = match.NextMatch();
				}
			}

			Console.WriteLine();
		}
	}
}