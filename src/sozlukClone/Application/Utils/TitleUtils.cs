using System.Globalization;
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

            return slug;
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
    }
}
