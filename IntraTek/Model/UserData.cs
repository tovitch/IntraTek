using System.Net.Http;

namespace IntraTek.Model
{
    public class UserData
    {
        public string login;
        private string access_token;
        public FormUrlEncodedContent encoded_access_token;

        public UserData(string login, string access_token)
        {
            this.login = login;
            this.access_token = access_token;
        }

        public UserData(string login, string access_token, FormUrlEncodedContent encoded_access_token)
        {
            this.login = login;
            this.access_token = access_token;
            this.encoded_access_token = encoded_access_token;
        }
    }
}