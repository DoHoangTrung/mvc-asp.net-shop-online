using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Hoc_ASP.NET_MVC.Models.Code
{
    public static class Extension
    {
        public static string ToVND(this double price)
        {
            return price.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
        }

        public static string ToVND(this double? price)
        {
            return price.GetValueOrDefault().ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
        }
        public static string ToVND(this decimal? price)
        {
            return price.GetValueOrDefault().ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
        }
        public static string ToVND(this decimal price)
        {
            return price.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
        }

        public static string Format(this string text)
        {
            //removeSpace
            text = text.Trim();
            text = Regex.Replace(text, @"\s+", " ");
            //lowercase and remove accents

            StringBuilder result = new StringBuilder();
            var arrayText = text.ToLower().Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char c in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    result.Append(c);
                }
            }

            return result.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}