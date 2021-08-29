using System;
using Terminal.Gui;

namespace nortoncommander
{
    public class DirectoryListView : ListView
    {
        public event Action OnEnterKey;
        
        public override bool ProcessKey(KeyEvent kb)
        {
            switch (kb.Key)
            {
                case Key.Enter:
                    OnEnterKey?.Invoke();
                    return true;
                default:
                    return base.ProcessKey(kb);
            }
        }
    }
}