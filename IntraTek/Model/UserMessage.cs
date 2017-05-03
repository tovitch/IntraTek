using Newtonsoft.Json.Linq;
using System;

namespace IntraTek.Model
{
    public class UserMessage
    {
        public string id { get; set; }
        public string title { get; set; }
        public User user { get; set; }
        public string content { get; set; }
        public string date { get; set; }

        public UserMessage(string id, string title, JObject userjo, string content, string date)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.date = date;
            if (userjo["picture"].Type == JTokenType.Null)
                this.user = new User("ms-appx://IntraTek/Assets/no_picture.png", userjo["title"].ToString(), userjo["url"].ToString());
            else
                this.user = new User(userjo["picture"].ToString(), userjo["title"].ToString(), userjo["url"].ToString());
        }

        public UserMessage()
        {
            id = "0";
            title = "";
            content = "Aucun nouveau message";
            date = DateTime.Today.ToString();
            user = new User("ms-appx://IntraTek/Assets/no_picture.png", "", "");
        }

        public class User
        {
            public string picture { get; set; }
            public string title { get; set; }
            public string url { get; set; }

            public User(string picture, string title, string url)
            {
                this.picture = picture;
                this.title = title;
                this.url = url;
            }
        }
    }
}
