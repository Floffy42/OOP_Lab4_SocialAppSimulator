using System.Text;

namespace OOP_Lab4_SocialAppSimulator
{
    internal class Program
    {
        public static User? OurUser { get; private set; } = null;
        public static List<User> UsersOnServer { get; private set; }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            /*
                        [+] В системі є користувачі
                        [+] кожен користувач має ім'я , імейл та нікнейм ( @nickname) - дані описані в коді
                        [+] у кожного користувача є його пости в соц мережі
                        [+] кожен пост має дату створення, текст поста, кількість лайків, коментарі до посту
                        [+] користувач може отримати остані 5 постів іншого користувача(вивести в консоль повну інформацію про остані 5 постів)
                        [+] коистувач може поставити лайк чи написати коментар до поста іншого користувача
                        [] користувач може створити собі новий пост
                        [] користувач може видалити свій пост
                        [] Для виконання роботи використовуйте класи.структури та функції для організації коду.
            */

            try
            {
                UsersOnServer = CreateTaskUsers();
                if (OurUser == null)
                {
                    CreateOurUser();
                    UsersOnServer.Add(OurUser);
                }
                CreatePosts();
                AddComments();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"1 - Переглянути останні пости");
                    Console.WriteLine($"2 - Створити пост");
                    Console.WriteLine($"3 - Видалити пост");
                    Console.Write($"Оберіть дію: ");
                    int action = Convert.ToInt32(Console.ReadLine());

                    switch (action)
                    {
                        case 1:
                            GetLastPosts();
                            break;
                        case 2:
                            //CreatePost();
                            break;
                        case 3:
                            //DeletePost();
                            break;
                        default:
                            Console.WriteLine("Невірний вибір");
                            break;
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка {ex.Message}");
            }

        }

        private static void CreateOurUser()
        {
            Console.Clear();
            Console.Write($"Введіть ім'я: ");
            string? name = Console.ReadLine();
            Console.Write($"Введіть email: ");
            string? email = Console.ReadLine();
            Console.Write($"Введіть нікнейм: ");
            string? nickname = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nickname))
            {
                throw new Exception("Всі поля повинні бути заповнені");
            }
            if (UsersOnServer.Contains(new User(name, email, nickname)))
            {
                throw new Exception("Користувач з такими даними вже існує");
            }

            OurUser = new User(name, email, nickname);
        }

        private static List<User> CreateTaskUsers()
        {
            List<User> tempList = new List<User>();

            tempList.Add(new User("Ігор", "igoryao@mail.mail", "DarkLord"));
            tempList.Add(new User("Олена", "olenka@mail.mail", "Sunshine"));
            tempList.Add(new User("Максим", "max001@mail.mail", "MaxPower"));
            tempList.Add(new User("Анастасія", "anastasia@mail.mail", "StarGazer"));
            tempList.Add(new User("Віктор", "viktorviktor@mail.mail", "TechMaster"));
            tempList.Add(new User("Катерина", "kitkat@mail.mail", "Moonlight"));

            return tempList;
        }

        private static void CreatePosts()
        {
            foreach (var user in UsersOnServer)
            {
                Random rand = new Random();
                int postCount = rand.Next(1, 6);
                for (int i = 0; i < postCount; i++)
                {
                    user.CreatePost(new Post($"Пост {i + 1} від {user.Nickname}", user));
                }
            }
        }
        private static void AddComments()
        {
            Random rand = new Random();
            foreach (var user in UsersOnServer)
            {
                foreach (var post in user.Posts)
                {
                    int commentCount = rand.Next(0, 4);
                    for (int i = 0; i < commentCount; i++)
                    {
                        User randomUser = UsersOnServer[rand.Next(UsersOnServer.Count)];
                        post.AddComment(new Comment($"Коментар {i + 1} від {randomUser.Nickname}", randomUser));
                    }
                }
            }
        }

        private static void GetLastPosts()
        {
            Console.Clear();
            Console.WriteLine($"Оберіть користувача для перегляду постів:");

            for (int i = 0; i < UsersOnServer.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {UsersOnServer[i].Nickname}");
            }

            Console.Write($"Вибір: ");
            int userIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.Clear();
            if (userIndex < 0 || userIndex >= UsersOnServer.Count)
            {
                Console.WriteLine("Невірний вибір користувача");
                Console.ReadKey();
                return;
            }

            User selectedUser = UsersOnServer[userIndex];
            WriteLastPosts(selectedUser);
            List<Post> lastPosts = selectedUser.Posts.OrderByDescending(p => p.CreationDate).Take(5).ToList();


        }
        private static void WriteLastPosts(User selectedUser)
        {
            List<Post> lastPosts = selectedUser.Posts.OrderByDescending(p => p.CreationDate).Take(5).ToList();
            foreach (var post in lastPosts)
            {
                Console.WriteLine($"Пост від {post.Author.Nickname} ({post.CreationDate}): {post.Text}");
                Console.WriteLine($"Лайки: {post.LikesCount}, Коментарі: {post.Comments.Count}");
                foreach (var comment in post.Comments)
                {
                    Console.WriteLine($"    Коментар від {comment.Author.Nickname} ({comment.CreationDate}): {comment.Text}");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine($"Оберіть дію:");
            Console.WriteLine($"1 - Поставити або прибрати лайк");
            Console.WriteLine($"2 - Написати коментар");
            Console.WriteLine($"3 - Повернутися");
            Console.Write($"Вибір: ");
            int action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case 1:
                    Console.Write("Оберіть пост для лайку: ");
                    int num = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (num >= 0 && num < lastPosts.Count)
                    {
                        Post post = lastPosts[num];
                        post.ToggleLike(OurUser);
                        Console.Clear();
                        WriteLastPosts(selectedUser);
                    }

                    break;
                case 2:
                    Console.Write("Оберіть пост для коментаря: ");
                    int postIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                    if(postIndex >= 0 && postIndex < lastPosts.Count)
                    {
                        Post post = lastPosts[postIndex];
                        Console.Write("Введіть текст коментаря: ");
                        string commentText = Console.ReadLine();
                        if (!string.IsNullOrEmpty(commentText))
                        {
                            Comment comment = new Comment(commentText, OurUser);
                            post.AddComment(comment);
                            Console.Clear();
                            WriteLastPosts(selectedUser);
                        }
                    }
                    break;
                case 3:
                    return;
                default:
                    return;
            }
        }
    }
}
