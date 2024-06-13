using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Application.Utils
{
    internal static class TitleUtils
    {
        public static string GenerateSlug(string title)
        {
            string normalizedTitle = RemoveDiacritics(title);

            normalizedTitle = normalizedTitle.ToLower();

            string slug = Regex.Replace(Regex.Replace(normalizedTitle, @"[\p{P}]+", ""), @"\s+", "-");

            slug = slug.Trim('-');

            string uniqueIdentifier = GenerateUniqueIdentifier();
            string uniqueSlug = $"{slug}--{uniqueIdentifier}";

            return uniqueSlug;
        }

        private static string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (c == 'ı')
                {
                    stringBuilder.Append('i');
                }
                else if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }


        private static string GenerateUniqueIdentifier()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var randomNumber = new byte[4];
                rng.GetBytes(randomNumber);
                int result = BitConverter.ToInt32(randomNumber, 0) & 0x7FFFFFFF; // Ensure it's non-negative
                return (result % 9999999 + 1).ToString(); // Range from 1 to 9999999
            }
        }
    }
}
