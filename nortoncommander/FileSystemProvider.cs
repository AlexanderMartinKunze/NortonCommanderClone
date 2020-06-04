using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace nortoncommander
{
    public class FileSystemProvider
    {
        public static string GetCurrentDirectory() => Directory.GetCurrentDirectory();

        public static IEnumerable<NCFileInfo> CreateFileList(string path) {
            var files = Directory.EnumerateFileSystemEntries(path, "", SearchOption.TopDirectoryOnly);
            var result = files.Select(file => new NCFileInfo {Name = NormalizedName(file), IsDirectory = IsDirectory(file), IsSelected = false}).ToList();

            result = Sort(result);

            if (!IsRootPath(path)) {
                result.Insert(0, new NCFileInfo {
                    Name = "..",
                    IsDirectory = true,
                    IsSelected = false
                });
            }

            result[0].IsSelected = true;

            return result;
        }

        private static string NormalizedName(string file) => new FileInfo(file).Name;

        private static bool IsDirectory(string file) {
            return (File.GetAttributes(file) & FileAttributes.Directory) == FileAttributes.Directory;
        }

        private static List<NCFileInfo> Sort(List<NCFileInfo> result) => result.OrderBy(f => !f.IsDirectory).ThenBy(f => f.Name).ToList();

        private static bool IsRootPath(string path) => new DirectoryInfo(path).Root.Name == path;

        public static string ChangeDirectory(int selectedIndex,
                                             string path,
                                             IEnumerable<NCFileInfo> files)
        {
            var selectedFile = files.ElementAt(selectedIndex);
            if (!selectedFile.IsDirectory)
            {
                return path;
            }
            var newPath = CombinedPath(path, selectedFile.Name);
            return newPath;
        }

        private static string CombinedPath(
            string currentPath,
            string path) 
        {
            var newPath = Path.Combine(currentPath, path);
            return new FileInfo(newPath).FullName;
        }
    }
}