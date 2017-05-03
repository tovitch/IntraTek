using IntraTek.View;
using System;
using System.Windows.Input;

namespace IntraTek.ViewModel
{
    public class MenuViewModel
    {
        #region UserCommand
        private ICommand _userCommand;
        public ICommand UserCommand
        {
            get
            {
                if (_userCommand == null)
                    _userCommand = new RelayCommand(() => goToPage(typeof(UserPage)));
                return _userCommand;
            }
        }
        #endregion
        #region ModuleCommand
        private ICommand _moduleCommand;
        public ICommand ModuleCommand
        {
            get
            {
                if (_moduleCommand == null)
                    _moduleCommand = new RelayCommand(() => goToPage(typeof(ModulePage)));
                return _moduleCommand;
            }
        }
        #endregion
        #region BoardCommand
        private ICommand _boardCommand;
        public ICommand BoardCommand
        {
            get
            {
                if (_boardCommand == null)
                    _boardCommand = new RelayCommand(() => goToPage(typeof(BoardPage)));
                return _boardCommand;
            }
        }
        #endregion

        public MenuViewModel()
        {
        }

        public void goToPage(Type page)
        {
            Windows.UI.Xaml.Window window = Windows.UI.Xaml.Window.Current;
            if (window != null)
            {
                Windows.UI.Xaml.Controls.Frame frame = window.Content as Windows.UI.Xaml.Controls.Frame;
                if (frame != null)
                {
                    frame.Navigate(page);
                }
            }
        }
    }
}
