using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4_SocialAppSimulator
{
    internal class Comment
    {
        public string Text { get; private set; } = "";
        public User Author { get; private set; }
        public DateTime CreationDate { get; private set; }

        public Comment(string text, User author)
        {
            SetText(text);
            Author = author;
            CreationDate = DateTime.Now;
        }
        private void SetText(string text)
        {
            if (!string.IsNullOrEmpty(text) && text.Length < 200) Text = text.Trim();
            else throw new Exception("Неправильний формат коментаря");
        }
    }
}
