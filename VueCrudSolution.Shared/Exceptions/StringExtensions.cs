using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VueCrudSolution.Shared.Exceptions
{
    public static class StringExtensions
    {
        public static string GenerateRandom(this string value, int length)
        {
            Random random = new Random();
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string number = "0123456789";
            const string symbol = "~!@#$%^&*?-_";
            string tmp = "", final = "";


            final = new string(Enumerable.Repeat(upper + lower + number + symbol, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return final;
        }

        public static string GenerateRandomNumber(this string value, int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
