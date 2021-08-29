using System;
using System.Collections.Generic;

namespace parseIntReloaded
{
    public class Parser
    {
        private Dictionary<string, int> _dictionary = new Dictionary<string, int>();

        private void FillDictionary()
        {
            _dictionary.Add("", 0);
            _dictionary.Add("one", 1);
            _dictionary.Add("two", 2);
            _dictionary.Add("three", 3);
            _dictionary.Add("four", 4);
            _dictionary.Add("five", 5);
            _dictionary.Add("six", 6);
            _dictionary.Add("seven", 7);
            _dictionary.Add("eight", 8);
            _dictionary.Add("nine", 9);
            _dictionary.Add("ten", 10);
            _dictionary.Add("eleven", 11);
            _dictionary.Add("twelve", 12);
            _dictionary.Add("thirteen", 13);
            _dictionary.Add("fourteen", 14);
            _dictionary.Add("fifteen", 15);
            _dictionary.Add("sixteen", 16);
            _dictionary.Add("seventeen", 17);
            _dictionary.Add("eighteen", 18);
            _dictionary.Add("nineteen", 19);
            _dictionary.Add("twenty", 20);
            _dictionary.Add("thirty", 30);
            _dictionary.Add("forty", 40);
            _dictionary.Add("fifty", 50);
            _dictionary.Add("sixty", 60);
            _dictionary.Add("seventy", 70);
            _dictionary.Add("eighty", 80);
            _dictionary.Add("ninety", 90);
        }

        public Parser()
        {
            FillDictionary();
        }

        public static int ParseInt(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;

            string cleanedString = s.Trim().ToLower();
            string[] splitValue;
            switch (cleanedString)
            {
                    
                case "million":
                    splitValue = cleanedString.Split("million");
                    return 1000000 * ParseInt(splitValue[0] + splitValue[1]);
            }
            return 0;
        }
    }
}