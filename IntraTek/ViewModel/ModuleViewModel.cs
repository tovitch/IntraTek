using IntraTek.Model;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace IntraTek.ViewModel
{
    public class ModuleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Modules
        private ObservableCollection<Module> _modules;

        public ObservableCollection<Module> Modules
        {
            get
            {
                if (_modules == null)
                    _modules = new ObservableCollection<Module>();
                return _modules;
            }
            set
            {
                _modules = value;
            }
        }
        #endregion

        public ModuleViewModel()
        {
            Task.Run(() =>
            {
                CoreDispatcher dispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    GetModules(WebRequest.Instance.ExecuteRequest("/user/" + WebRequest.Instance.userData.login + "/notes/"));
                });
#pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            });
        }

        private void GetModules(string jsonString)
        {
            JObject jobject = JObject.Parse(jsonString);
            JArray module = JArray.Parse(jobject["modules"].ToString());

            foreach (var item in module)
            {
                Debug.WriteLine("item: " + item.ToString());
                var m = new Module(JObject.Parse(item.ToString()));
                Modules.Add(m);
            }
            for (int i = 0; i < Modules.Count; i++)
                Modules.Move(Modules.Count - 1, i);
        }
    }
}
