using IntraTek.Model;
using IntraTek.View;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;

namespace IntraTek.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region UserLogin
        private string _userLogin;
        public string UserLogin
        {
            get
            {
                return _userLogin;
            }
            set
            {
                _userLogin = value;
                NotifyPropertyChanged("UserLogin");
            }
        }
        #endregion
        #region UserPassword
        private string _userPassword;
        public string UserPassword
        {
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
                NotifyPropertyChanged("UserPassword");
            }
        }
        #endregion
        #region LoginButton
        private ICommand _loginButton;
        public ICommand LoginButton
        {
            get
            {
                if (_loginButton == null)
                    _loginButton = new RelayCommand(() => loginButtonAction());
                return _loginButton;
            }
            private set { _loginButton = value; }
        }
        private void loginButtonAction()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("login", UserLogin),
                new KeyValuePair<string, string>("password", UserPassword)
            });
            if (WebRequest.Instance.GetAccessToken(content, UserLogin) == true)
            {
                Windows.UI.Xaml.Window window = Windows.UI.Xaml.Window.Current;
                if (window != null)
                {
                    Windows.UI.Xaml.Controls.Frame frame = window.Content as Windows.UI.Xaml.Controls.Frame;
                    if (frame != null)
                    {
                        frame.Navigate(typeof(UserPage));
                    }
                }
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public MainViewModel()
        {
        }
    }
}
