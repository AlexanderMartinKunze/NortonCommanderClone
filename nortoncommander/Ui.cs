using System;
using System.Collections.Generic;
using Terminal.Gui;

namespace nortoncommander
{
    public class Ui
    {
        private static DirectoryListView _leftList;
        private static DirectoryListView _rightList;

        public event Action<int> OnLeftFile;
        public event Action<int> OnRightFile;
        
        public Ui() {
            Application.Init();
            CreateView(Application.Top);
        }

        public void UpdateLeftList(IEnumerable<NCFileInfo> files) {
            _leftList.Source = new FileListDataSource(files);
        }

        public void UpdateRightList(IEnumerable<NCFileInfo> files) {
            _rightList.Source = new FileListDataSource(files);
        }

        private void CreateView(Toplevel top) {
            var leftWin = new Window("Links") {
                X = 0,
                Y = 1, // one line for the menu
                Width = Dim.Percent(50),
                Height = Dim.Fill()
            };
            top.Add(leftWin);

            var rightWin = new Window("Rechts") {
                X = Pos.Right(leftWin),
                Y = 1, // one line for the menu
                Width = Dim.Width(leftWin),
                Height = Dim.Fill()
            };
            top.Add(rightWin);

            var menu = new MenuBar(new[] {
                new MenuBarItem("_File", new[] {
                    new MenuItem("_Quit", "", () => { top.Running = false; })
                })
            });
            top.Add(menu);

            _leftList = new DirectoryListView {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            _leftList.CanFocus = true;
            _leftList.OnEnterKey += () => OnLeftFile(_leftList.SelectedItem);
            leftWin.Add(_leftList);

            _rightList = new DirectoryListView {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            _rightList.CanFocus = true;
            _rightList.OnEnterKey += () => OnRightFile(_rightList.SelectedItem);
            rightWin.Add(_rightList);
        }
    }
}