using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebProje.App_Code
{
    public class Seo
    {
        public static string FolderNameEdit(string folderName)
        {
            string NoUrlFolderName = Path.GetFileNameWithoutExtension(folderName);
            string url = Path.GetExtension(folderName);
            return UrlEdit(NoUrlFolderName) + url;
        }

        public static string UrlEdit(object a)
        {
            string s = a.ToString();
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            if (s.Length > 80)
            {
                s = s.Substring(0, 80);
            }

            s = s.Replace("ş", "s"); //karakter değişimi için kullanılır
            s = s.Replace("Ş", "S");
            s = s.Replace("ğ", "g");
            s = s.Replace("Ğ", "G");
            s = s.Replace("İ", "I");
            s = s.Replace("ı", "i");
            s = s.Replace("ç", "c");
            s = s.Replace("Ç", "C");
            s = s.Replace("ö", "o");
            s = s.Replace("Ö", "O");
            s = s.Replace("ü", "u");
            s = s.Replace("Ü", "U");
            s = s.Replace("'", "");
            s = s.Replace("\"", "");
            Regex r = new Regex("[^a-zA-Z0-9_-]");
            //if (r.IsMatch(s))
            s = r.Replace(s, "-");
            if (!string.IsNullOrEmpty(s))
                while (s.IndexOf("--") > -1)
                    s = s.Replace("--", "-");
            if (s.StartsWith("-")) s = s.Substring(1);
            if (s.EndsWith("-")) s = s.Substring(0, s.Length - 1);
            return s;
        }
    }
}