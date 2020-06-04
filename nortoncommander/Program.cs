using Terminal.Gui;

namespace nortoncommander
{
    class Program
    {
        static void Main(string[] args) {
            var ui = new Ui();
            var interactors = new Interactors();

            void Start() {
                var files = interactors.Start();
                ui.UpdateLeftList(files);
                ui.UpdateRightList(files);
            }

            ui.OnLeftFile += selectedIndex => {
                var files = interactors.ChangeDirectoryLeft(selectedIndex);
                ui.UpdateLeftList(files);
            };
            ui.OnRightFile += selectedIndex => {
                var files = interactors.ChangeDirectoryRight(selectedIndex);
                ui.UpdateRightList(files);
            };

            Start();
            Application.Run();
        }
    }
}