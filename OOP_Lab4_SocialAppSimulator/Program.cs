using System.Text;

namespace OOP_Lab4_SocialAppSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            /*
                        [+] В системі є користувачі
                        [+] кожен користувач має ім'я , імейл та нікнейм ( @nickname) - дані описані в коді
                        [] у кожного користувача є його пости в соц мережі
                        [] кожен пост має дату створення, текст поста, кількість лайків, коментарі до посту
                        [] користувач може отримати остані 5 постів іншого користувача(вивести в консоль повну інформацію про остані 5 постів)
                        [] коистувач може поставити лайк чи написати коментар до поста іншого користувача
                        [] користувач може створити собі новий пост
                        [] користувач може видалити свій пост
                        [] Для виконання роботи використовуйте класи.структури та функції для організації коду.
            */

            try
            {
                List<User> usersOnServer = CreateTaskUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка {ex.Message}");
            }

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
    }
}
