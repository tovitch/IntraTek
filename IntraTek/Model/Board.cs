using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace IntraTek.Model
{
    public class Board
    {
        private JObject bord;
        #region Projects
        private ObservableCollection<Project> projects;
        public ObservableCollection<Project> Projects
        {
            get
            {
                if (projects == null)
                    projects = new ObservableCollection<Project>();
                return projects;
            }
            set
            {
                projects = value;
            }
        }
        #endregion
        #region Modules
        private ObservableCollection<Module> modules;
        public ObservableCollection<Module> Modules
        {
            get
            {
                if (modules == null)
                    modules = new ObservableCollection<Module>();
                return modules;
            }
            set
            {
                modules = value;
            }
        }
        #endregion
        #region NotImplemented
        #region Notes
        // TODO: à implémenter
        #endregion
        #region Susies
        // TODO: à implémenter
        #endregion
        #region Activites
        // TODO: à implémenter
        #endregion
        #region Stages
        // TODO: à implémenter
        #endregion
        #region Tickets
        // TODO: à implémenter
        #endregion        #endregion
        #endregion

        public Board()
        {
            bord = JObject.Parse(WebRequest.Instance.ExecuteRequest("/"));
            GetProjects();
        }

        private void GetProjects()
        {
            var projects = JArray.Parse(bord["board"]["projets"].ToString());

            foreach (var item in projects)
            {
                Projects.Add(new Project(JObject.Parse(item.ToString())));
            }
        }

        private void GetModules()
        {
        }
    }
}
