using Newtonsoft.Json.Linq;

namespace IntraTek.Model
{
    public class Project
    {
        public string Title { get; set; }
        public string TitleLink { get; set; }
        public string TimelineStart { get; set; }
        public string TimelineEnd { get; set; }
        public string TimelineBarre { get; set; }
        public string DateInscription { get; set; }
        public string IdActivity { get; set; }
        public string SoutenanceName { get; set; }
        public string SoutenanceLink { get; set; }
        public string SoutenanceDate { get; set; }
        public string SoutenanceSalle { get; set; }

        public Project(JObject o)
        {
            Title = o["title"].ToString();
            TitleLink = o["title_link"].ToString();
            TimelineStart = o["timeline_start"].ToString();
            TimelineEnd = o["timeline_end"].ToString();
            TimelineBarre = o["timeline_barre"].ToString();
            DateInscription = o["date_inscription"].ToString();
            IdActivity = o["id_activite"].ToString();
            SoutenanceName = o["soutenance_name"].ToString();
            SoutenanceName = o["soutenance_link"].ToString();
            SoutenanceName = o["soutenance_date"].ToString();
            SoutenanceName = o["soutenance_salle"].ToString();
        }
    }
}