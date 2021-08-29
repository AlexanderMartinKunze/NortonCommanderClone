using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace WhereMyAnagramsTests
{
    public class Tests
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new List<string> {"a"},
                WhereMyAnagrams.Program.Anagrams("a", new List<string> {"a", "b", "c", "d"}));
            Assert.AreEqual(new List<string> {"carer", "arcre", "carre"},
                WhereMyAnagrams.Program.Anagrams("racer", new List<string> {"carer", "arcre", "carre", "racrs", "racers", "arceer", "raccer", "carrer", "cerarr"}));
        }
    }
}