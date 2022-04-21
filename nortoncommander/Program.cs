using System.Collections.Generic;
using Terminal.Gui;

namespace nortoncommander
{
    class Program
    {
        static void Main(string[] args)
        {
            Ui ui = new Ui();
            Interactors interactors = new Interactors();

            void Start() 
            {
                IEnumerable<NCFileInfo> files = interactors.Start();
                ui.UpdateLeftList(files);
                ui.UpdateRightList(files);
            }

            ui.OnLeftFile += selectedIndex => 
            {
                IEnumerable<NCFileInfo> files = interactors.ChangeDirectoryLeft(selectedIndex);
                ui.UpdateLeftList(files);
            };

            ui.OnRightFile += selectedIndex => 
            {
                IEnumerable<NCFileInfo> files = interactors.ChangeDirectoryRight(selectedIndex);
                ui.UpdateRightList(files);
            };

            Start();
            Application.Run();
        }
    }
}