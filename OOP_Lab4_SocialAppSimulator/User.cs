using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OOP_Lab4_SocialAppSimulator
{
    internal class User
    {
        private string _name = "";
        private string _email = "";
        public string Nickname { get; private set; } = "";
        public List<Post> Posts { get; private set; } = new List<Post>();
        public User(string name, string email, string nickname)
        {
            SetName(name);
            SetEmail(email);
            ChangeNickname(nickname);
        }


        public void SetEmail(string email)
        {
            if (email.Contains('@') && !string.IsNullOrEmpty(email))
            {
                _email = email.Trim();
            }
            else
            {
                throw new Exception("Неправильний формат пошти");
            }
        }
        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name) && name.Length < 10) _name = name.Trim();
            else throw new Exception("Неправильний формат імені");
        }
        public void ChangeNickname(string nick)
        {
            if (!string.IsNullOrEmpty(nick) && nick.Length < 15) Nickname = $"@{nick.Trim()}";
            else throw new Exception("Неправильний формат нікнейму");
        }

        public void CreatePost(Post post)
        {
            Posts.Add(post);
        }
        public string GetEmail() => _email;
        public string GetName() => _name;
    }
}
