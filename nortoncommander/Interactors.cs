using System.Collections.Generic;

namespace nortoncommander
{
    public class Interactors
    {
        private IEnumerable<NCFileInfo> _leftFiles;
        private IEnumerable<NCFileInfo> _rightFiles;
        private string _leftPath;
        private string _rightPath;
        
        
        public IEnumerable<NCFileInfo> Start() {
            var currentDirectory = FileSystemProvider.GetCurrentDirectory();
            _leftFiles = FileSystemProvider.CreateFileList(currentDirectory);
            _rightFiles = _leftFiles;
            _leftPath = currentDirectory;
            _rightPath = currentDirectory;
            return _leftFiles;
        }

        public IEnumerable<NCFileInfo> ChangeDirectoryLeft(in int selectedIndex) {
            _leftPath = FileSystemProvider.ChangeDirectory(selectedIndex, _leftPath, _leftFiles);
            _leftFiles = FileSystemProvider.CreateFileList(_leftPath);
            return _leftFiles;
        }
        
        public IEnumerable<NCFileInfo> ChangeDirectoryRight(in int selectedIndex) {
            _rightPath = FileSystemProvider.ChangeDirectory(selectedIndex, _rightPath, _rightFiles);
            _rightFiles = FileSystemProvider.CreateFileList(_rightPath);
            return _rightFiles;
        }
    }
}