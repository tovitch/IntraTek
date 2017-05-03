using Newtonsoft.Json.Linq;

namespace IntraTek.Model
{
    public class UserInformation
    {
        private JObject jobject;

        public UserInformation(string jsonString)
        {
            jobject = JObject.Parse(jsonString);
        }

        public string GetFullname()
        {
            return jobject.GetValue("title").ToString();
        }

        public string GetPromoYear()
        {
            return jobject.GetValue("promo").ToString();
        }

        public string GetPicture()
        {
            return jobject.GetValue("picture").ToString();
        }

        public string GetSemesterCode()
        {
            return jobject.GetValue("semester_code").ToString();
        }

        public string GetStudentYear()
        {
            return jobject.GetValue("studentyear").ToString();
        }

        public string GetCredits()
        {
            return jobject.GetValue("credits").ToString();
        }

        public string GetGPA()
        {
            return jobject["gpa"][0]["gpa"].ToString();
        }

        public string GetCycle()
        {
            return jobject["gpa"][0]["cycle"].ToString();
        }

        public string GetSpice()
        {
            return jobject["spice"]["available_spice"].ToString();
        }
    }
}
