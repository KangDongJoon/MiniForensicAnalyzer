using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniForensicAnalyzer.Services
{
    class FileAnalysisService
    {
        public string GetHex(string path)
        {
            byte[] fileBytes = File.ReadAllBytes(path);

            StringBuilder sb = new StringBuilder();

            foreach (byte b in fileBytes)
            {
                sb.Append(b.ToString("X2"));
                sb.Append(" ");
            }

            return sb.ToString();
        }

        public string CalculateSHA256(string path)
        {
            byte[] fileBytes = File.ReadAllBytes(path);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(fileBytes);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public string ExtractString(string path)
        {
            byte[] fileBytes = File.ReadAllBytes(path);

            string text = Encoding.ASCII.GetString(fileBytes);

            MatchCollection matches = Regex.Matches(text, @"[ -~]{4,}");

            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            {
                sb.AppendLine(match.Value);
            }

            return sb.ToString();
        }
    }
}
