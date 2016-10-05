using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApp
{
    public static class NumTranslator
    {
        public static string ToNum(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return "";
            else
            {
                raw = raw.ToUpperInvariant();
            }
            var newNum = new StringBuilder();
            foreach (var c in raw)
            {
                if (" -012345678".Contains(c))
                    newNum.Append(c);
                else
                {
                    var result = TranstoNum(c);
                    if (result != null)
                        newNum.Append(result);
                }
            }
            return newNum.ToString();
        }

        static bool Contais(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        private static int? TranstoNum(char c)
        {
            if ("ABC".Contains(c))
                return 2;
            else if ("DEF".Contains(c))             //look at your phone's dialer
                return 3;                           //numbers have small letters next to them?
            else if ("GHI".Contains(c))             // well, here they are
                return 4;
            else if ("JKL".Contains(c))
                return 5;
            else if ("MNO".Contains(c))
                return 6;
            else if ("PQRS".Contains(c))
                return 7;
            else if ("TUV".Contains(c))
                return 8;
            else if ("WXYZ".Contains(c))
                return 9;
            return null;
        }
        
    }

}