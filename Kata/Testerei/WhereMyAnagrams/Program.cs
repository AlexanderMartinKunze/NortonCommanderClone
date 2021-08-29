using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereMyAnagrams
{
    public static class Program
    {
        public static List<string> Anagrams(string word, List<string> words)
        {     
            var wordArr = word.ToList().OrderBy(w => w).ToList();
            var retVals = new List<string>();
     
            foreach (string wrd in words)
            {
                var wordTempArr = wrd.ToList().OrderBy(w => w).ToList();
                if (wordTempArr.SequenceEqual(wordArr))
                {
                    retVals.Add(wrd);
                }
            }
    
            return retVals;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(Anagrams("a", new List<string>{"a", "b", "c", "d"}));


        }
    }
}