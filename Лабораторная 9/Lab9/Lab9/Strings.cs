using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    static public class ChangingStrings
    {
        public static string TaskToLower(string str)
        {
            str = str.ToLower();
            return str;
        }

        public static string AddChar(string str, char letter)
        {
            str += letter;
            return str;
        }

        public static string AddExclamation(string str)
        {
            str += "!";
            return str;
        }

        public static string TaskToUpper(string str)
        {
            str = str.ToUpper();
            return str;
        }

        public static string Change(string str)
        {
            str = str.Replace("i", "I");
            return str;
        }
    }
}
