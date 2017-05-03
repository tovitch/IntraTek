using IntraTek.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace IntraTek.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly string userPath = "/user/";
        private readonly string alertPath = "/user/notification/alert/";
        private readonly string messagePath = "/user/notification/message/";

        private UserInformation infos;

        #region UserPicture
        private string _userPicture;
        public string UserPicture
        {
            get
            {
                return _userPicture;
            }
            set
            {
                _userPicture = value;
                NotifyPropertyChanged("UserPicture");
            }
        }
        #endregion
        #region UserFullname
        private string _userFullname;
        public string UserFullname
        {
            get
            {
                return _userFullname;
            }
            set
            {
                _userFullname = value;
                NotifyPropertyChanged("UserFullname");
            }
        }
        #endregion
        #region UserCredits
        private string _userCredits;
        public string UserCredits
        {
            get
            {
                return _userCredits;
            }
            set
            {
                _userCredits = value;
                NotifyPropertyChanged("UserCredits");
            }
        }
        #endregion
        #region UserSpices
        private string _userSpices;
        public string UserSpices
        {
            get
            {
                return _userSpices;
            }
            set
            {
                _userSpices = value;
                NotifyPropertyChanged("UserSpices");
            }
        }
        #endregion
        #region UserGPA
        private string _userGPA;
        public string UserGPA
        {
            get
            {
                return _userGPA;
            }
            set
            {
                _userGPA = value;
                NotifyPropertyChanged("UserGPA");
            }
        }
        #endregion
        #region UserMessage
        private ObservableCollection<UserMessage> _userMessages;
        public ObservableCollection<UserMessage> UserMessages
        {
            get
            {
                if (_userMessages == null)
                    _userMessages = new ObservableCollection<UserMessage>();
                return _userMessages;
            }
            set
            {
                _userMessages = value;
                NotifyPropertyChanged("UserMessages");
            }
        }
        #endregion
        #region UserAlert
        private ObservableCollection<string> _userAlert;
        public ObservableCollection<string> UserAlert
        {
            get
            {
                if (_userAlert == null)
                    _userAlert = new ObservableCollection<string>();
                return _userAlert;
            }
            set
            {
                _userAlert = value;
                NotifyPropertyChanged("UserAlert");
            }
        }
        #endregion

        public UserViewModel()
        {
            GetJsonObjects();
        }

        private void GetJsonObjects()
        {
            List<Task> tasks = new List<Task>();

            tasks.Add(new Task((path) =>
            {
                infos = new UserInformation(WebRequest.Instance.ExecuteRequest((string)path));
                CoreDispatcher dispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    UserPicture = infos.GetPicture();
                    UserFullname = infos.GetFullname();
                    UserCredits = infos.GetCredits();
                    UserSpices = infos.GetSpice();
                    UserGPA = infos.GetGPA();
                });
            }, userPath));
            tasks.Add(new Task((path) =>
            {
                CoreDispatcher dispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
                dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    GetAlerts(WebRequest.Instance.ExecuteRequest((string)path));
                });
            }, alertPath));
            tasks.Add(new Task((path) =>
            {
                CoreDispatcher dispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
                dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    GetMessages(WebRequest.Instance.ExecuteRequest((string)path));
                });
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            }, messagePath));
            tasks.ForEach(t => t.Start());
        }

        private void NotifyPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        private void GetAlerts(string jsonString)
        {
            JArray jarray = JArray.Parse(jsonString);

            foreach (JObject o in jarray.Children<JObject>())
            {
                foreach (JProperty p in o.Properties())
                {
                    UserAlert.Add(p.Value.ToString());
                }
            }
        }

        private void GetMessages(string jsonString)
        {
            if (jsonString.Equals("{}\n"))
            {
                UserMessages.Add(new UserMessage());
            }
            else
            {
                JArray jarray = JArray.Parse(jsonString);

                foreach (JObject o in jarray.Children<JObject>())
                {
                    var user = new UserMessage(o["id"].ToString(), o["title"].ToString(), (JObject)o["user"], o["content"].ToString(), o["date"].ToString());
                    UserMessages.Add(user);
                }
            }
        }
    }
}
