using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Windows.Storage;

namespace IntraTek.Model
{
    public sealed class WebRequest
    {
        private readonly string _baseAddress = "https://intra.epitech.eu";
        private readonly string _appDirName = "IntraTek";
        private readonly StorageFolder _appDirPath = ApplicationData.Current.LocalFolder;
        private HttpClient client;
        private FormUrlEncodedContent _access_token;
        public UserData userData;

        #region Instance
        private static WebRequest _instance;
        public static WebRequest Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WebRequest();
                return _instance;
            }
        }
        #endregion

        private WebRequest()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(_baseAddress);
            client.DefaultRequestHeaders
                .Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string ExecuteRequest(string path)
        {
            var result = client.PostAsync(path, userData.encoded_access_token).Result;
            string resultContent = result.Content.ReadAsStringAsync().Result;
            return resultContent;
        }

        public bool GetAccessToken(FormUrlEncodedContent content, string userLogin)
        {
            var result = client.PostAsync("/login/", content).Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                string resultContent = result.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(resultContent);
                if (json["message"].ToString().Equals("Success"))
                {
                    var access_token = json["access_token"].ToString();
                    _access_token = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("access_token", access_token)
                    });
                    userData = new UserData(userLogin, access_token, _access_token);
                    return true;
                }
            }
            return false;
        }
    }
}
