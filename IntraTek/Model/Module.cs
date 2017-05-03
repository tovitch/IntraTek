using Newtonsoft.Json.Linq;

namespace IntraTek.Model
{
    public class Module
    {
        public int ScolarYear { get; set; }
        public string CodeModule { get; set; }
        public string IdUserHistory { get; set; }
        public string CodeInstance { get; set; }
        public string DateIns { get; set; }
        public string Title { get; set; }
        public string Cycle { get; set; }
        public string Grade { get; set; }
        public int Credits { get; set; }
        public string Barrage { get; set; }

        public Module(JObject jobject)
        {
            ScolarYear = int.Parse(jobject["scolaryear"].ToString());
            IdUserHistory = jobject["id_user_history"].ToString();
            CodeModule = jobject["codemodule"].ToString();
            CodeInstance = jobject["codeinstance"].ToString();
            Title = jobject["title"].ToString();
            DateIns = jobject["date_ins"].ToString();
            Cycle = jobject["cycle"].ToString();
            Grade = jobject["grade"].ToString();
            Credits = int.Parse(jobject["credits"].ToString());
            Barrage = jobject["barrage"].ToString();
        }

        public string TitleLink { get; set; }
        public string TimelineStart { get; set; }
        public string TimelineEnd { get; set; }
        public string TimelineBarre { get; set; }
        public string DateInscription { get; set; }

        /// <summary>
        /// Constructeur pour le board
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="ignored"></param>
        public Module(JObject jobject, bool ignored)
        {
            Title = jobject["title"].ToString();
            TitleLink = jobject["title_link"].ToString();
            TimelineStart = jobject["timeline_start"].ToString();
            TimelineEnd = jobject["timeline_end"].ToString();
            TimelineBarre = jobject["timeline_barre"].ToString();
            DateInscription = jobject["date_inscription"].ToString();
        }
    }
}
