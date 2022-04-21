using System.IO;
using System.Linq;
using NUnit.Framework;

namespace nortoncommander.tests
{
    [TestFixture]
    public class FileSystemProviderTests
    {
        [Test]
        public void Files_and_directories_are_read_correct() 
        {
            var result = FileSystemProvider.CreateFileList("testdata");
            
            Assert.That(result.Count(), Is.EqualTo(4));
            
            Assert.That(result.Select(f => f.Name), 
                Is.EqualTo(new[]{"..", "subDir", "testfile1.txt", "testfile2.txt"}));
            Assert.That(result.Select(f => f.IsDirectory), 
                Is.EqualTo(new[]{true, true, false, false}));
            Assert.That(result.Select(f => f.IsSelected), 
                Is.EqualTo(new[]{true, false, false, false}));
        }

        [Test]
        public void Can_change_directory_one_level_down() 
        {
            var path = FileSystemProvider.ChangeDirectory(0, "testdata", 
                new[]{new NCFileInfo {
                    Name = "subDir",
                    IsDirectory = true
                }});
            StringAssert.EndsWith("subDir", path);
        }

        [Test]
        public void Can_change_directory_one_level_up() 
        {
            var path = FileSystemProvider.ChangeDirectory(0, "testdata", 
                new[]{new NCFileInfo {
                    Name = "..",
                    IsDirectory = true
                }});
            var expectedPath = "nortoncommander.tests#bin#Debug#netcoreapp3.1";
            expectedPath = expectedPath.Replace('#', Path.DirectorySeparatorChar);
            StringAssert.EndsWith(expectedPath, path);
        }
    }
}