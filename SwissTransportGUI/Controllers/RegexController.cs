using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;

namespace SwissTransportGUI.Controllers
{
    public class RegexController
    {
        public static bool IsValidSearchQuery(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return false;

            string[] _badChars = new string[] { "@", "*", "#", "\"", "+", "¦", "§", "°", "&", "%", "/", "=", "?", "`", "'", "^", "$", "£" };
            bool _containsBadChar = false;
            foreach (string badChar in _badChars)
            {
                if (searchQuery.Contains(badChar))
                    _containsBadChar = true;
            }

            if (_containsBadChar)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsConnectedToInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
