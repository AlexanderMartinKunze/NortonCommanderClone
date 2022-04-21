using System.Collections.Generic;
using System.Linq;
using Terminal.Gui;

namespace nortoncommander
{
    public class FileListDataSource : IListDataSource
    {
        private readonly List<NCFileInfo> _files;

        public FileListDataSource(IEnumerable<NCFileInfo> files) {
            _files = files.ToList();
        }

        public void Render(ListView container, ConsoleDriver driver, bool selected, int item, int col, int line, int width)
        {
            driver.SetAttribute(selected ? container.ColorScheme.Focus : container.ColorScheme.Normal);

            container.Move(col, line);
            driver.AddStr(Format(_files[item], width));
            
            // Reset color to normal. Otherwise if last entry is selected
            // all lines below are drawn in focus color
            driver.SetAttribute (container.ColorScheme.Normal);   
        }

        public bool IsMarked(int item) => _files[item].IsSelected;

        public void SetMark(int item, bool value) => _files[item].IsSelected = value;

        public int Count => _files.Count;

        internal static string Format(NCFileInfo ncFileInfo, int width) {
            // 12345678901234567890123456789012345
            //          1         2         3
            //   <DIR>  12345 KB  04.02.2020 11:11
            //   12345 KB  04.02.2020 11:11
            int widthForFilename = width - 28 - 2;
            if (ncFileInfo.IsDirectory) {
                widthForFilename = width - 35 - 2;
            }

            if (widthForFilename < 10) {
                if (ncFileInfo.IsDirectory) {
                    int l = ncFileInfo.Name.Length < width - 9 ? ncFileInfo.Name.Length : width - 9;
                    string s = ncFileInfo.Name.Substring(0, l);
                    return " " + (s + " <DIR>").PadRight(width - 1);
                }

                int length = ncFileInfo.Name.Length < width - 3 ? ncFileInfo.Name.Length : width - 3;
                string substring = ncFileInfo.Name.Substring(0, length);
                return " " + substring.PadRight(width - 1);
            }
            
            string filename = ncFileInfo.Name;
            if (filename.Length > widthForFilename) {
                var startIndex = filename.Length - widthForFilename + 3;
                filename = "..." + filename.Substring(startIndex, widthForFilename - 3);
            }
            else {
                filename = filename.PadRight(widthForFilename);
            }
            
            string result = " " + filename;

            result = result.PadRight(widthForFilename);
            if (ncFileInfo.IsDirectory) {
                result += "  <DIR>  12345 KB  04.02.2020 11:11 ";
            }
            else {
                result += "  12345 KB  04.02.2020 11:11 ";
            }

            return result;
        }
    }
}