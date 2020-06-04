using System;
using Terminal.Gui;

namespace nortoncommander
{
    public class DirectoryListView : ListView
    {
        public event Action OnEnterKey;
        
        public override bool ProcessKey(KeyEvent kb) {
            if (kb.Key == Key.Enter) {
                OnEnterKey?.Invoke();
                return true;
            }
            return base.ProcessKey(kb);
        }
    }
}