using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4_SocialAppSimulator
{
    internal class Post
    {
        //дату створення, текст поста, кількість лайків, коментарі до посту
        public DateTime CreationDate { get; private set; }
        public string Text { get; private set; } = "";
        public int LikesCount { get; private set; } = 0;
        private List<User> _userLikes = new List<User>();
        public List<Comment> Comments { get; private set; } = new List<Comment>();
        public User Author { get; private set; }

        public Post(string text, User author)
        {
            CreationDate = DateTime.Now;
            SetText(text);
            Author = author;
        }
        private void SetText(string text)
        {
            if (!string.IsNullOrEmpty(text) && text.Length < 500) Text = text.Trim();
            else throw new Exception("Неправильний формат тексту поста");
        }
        public void ToggleLike(User user)
        {
            if (!_userLikes.Contains(user))
            {
                _userLikes.Add(user);
                LikesCount++;
            }
            else
            {
                _userLikes.Remove(user);
                LikesCount--;
            }
        }
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }
    }
}
