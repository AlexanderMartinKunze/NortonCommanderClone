using NUnit.Framework;

namespace nortoncommander.tests
{
    public class FileListDataSourceTests
    {
        [Test]
        public void File_with_enough_width() 
        {
            string result = FileListDataSource.Format(new NCFileInfo {
                Name = "1234567890.txt",
                IsDirectory = false
            }, 50);
            Assert.That(result, Is.EqualTo(" 1234567890.txt        12345 KB  04.02.2020 11:11 "));
        }

        [Test]
        public void File_with_not_enough_width() 
        {
            string result = FileListDataSource.Format(new NCFileInfo {
                Name = "1234567890.txt",
                IsDirectory = false
            }, 40);
            Assert.That(result, Is.EqualTo(" ...890.txt  12345 KB  04.02.2020 11:11 "));
        }

        [Test]
        public void File_with_very_small_width()
        {
            string result = FileListDataSource.Format(new NCFileInfo {
                Name = "1234567890.txt",
                IsDirectory = false
            }, 20);
            Assert.That(result, Is.EqualTo(" 1234567890.txt     "));
        }

        [Test]
        public void Directory_with_enough_width()
        {
            string result = FileListDataSource.Format(new NCFileInfo {
                Name = "1234567890",
                IsDirectory = true
            }, 50);
            Assert.That(result, Is.EqualTo(" 1234567890     <DIR>  12345 KB  04.02.2020 11:11 "));
        }

        [Test]
        public void Directory_with_not_enough_width() 
        {
            string result = FileListDataSource.Format(new NCFileInfo {
                Name = "1234567890",
                IsDirectory = true
            }, 47);
            Assert.That(result, Is.EqualTo(" 1234567890  <DIR>  12345 KB  04.02.2020 11:11 "));
        }

        [Test]
        public void Directory_with_very_small_width() 
        {
            string result = FileListDataSource.Format(new NCFileInfo {
                Name = "1234567890",
                IsDirectory = true
            }, 20);
            Assert.That(result, Is.EqualTo(" 1234567890 <DIR>   "));
        }
    }
}