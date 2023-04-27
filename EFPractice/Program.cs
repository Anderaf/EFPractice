using EFPractice.Entities;
using EFPractice.Repositories;

namespace EFPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var db = new AppContext())
            {
                var user1 = new User() { Name = "Имя", Email = "example@gmail.com" };
                var user2 = new User() { Name = "Имя2", Email = "example2@gmail.com" };
                var user3 = new User() { Name = "Имя3", Email = "example3@gmail.com" };
                UserRepository.AddUser(db, user1);
                UserRepository.AddUser(db, user2);
                UserRepository.AddUser(db, user3);

                var book1 = new Book() { Title = "Название", ReleaseDate = DateTime.Now, BookAuthor = "Автор", Genre = "Жанр" };
                var book2 = new Book() { Title = "Название2", ReleaseDate = DateTime.Now, BookAuthor = "Автор2", Genre = "Жанр2" };
                var book3 = new Book() { Title = "Название3", ReleaseDate = DateTime.Now, BookAuthor = "Автор3", Genre = "Жанр3" };
                BookRepository.AddBook(db, book1);
                BookRepository.AddBook(db, new Book() { Title = "Название", ReleaseDate = DateTime.Now, BookAuthor = "Автор", Genre = "Жанр"});
                BookRepository.AddBook(db, new Book() { Title = "Название", ReleaseDate = DateTime.Now, BookAuthor = "Автор", Genre = "Жанр"});

                UserRepository.GetBook(db, user1, book1);

                db.SaveChanges();
                foreach (var user in UserRepository.SelectAll(db))
                {
                    Console.WriteLine(user.Id + " " + user.Name + " " + user.Email + " " + user.OwnedBooks?.FirstOrDefault()?.Title);
                }
            }
        }
    }
}