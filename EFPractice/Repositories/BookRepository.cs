using EFPractice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractice.Repositories
{
    public static class BookRepository
    {
        public static Book SelectById(AppContext db, int id)
        {
            return db.Books.FirstOrDefault(u => u.Id == id);
        }
        public static List<Book> SelectAll(AppContext db)
        {
            return db.Books.ToList();
        }
        public static void AddBook(AppContext db, Book user)
        {
            db.Add(user);
        }
        public static void RemoveBook(AppContext db, Book user)
        {
            db.Remove(user);
        }
        public static void UpdateBookReleaseDateById(AppContext db, int id, DateTime date)
        {
            db.Books.FirstOrDefault(u => u.Id == id).ReleaseDate = date;
        }
        public static List<Book> GetBooksByGenreAndDateInterval(AppContext db, string genre, DateTime date1, DateTime date2)
        {
            return db.Books.Where(b => b.Genre == genre && b.ReleaseDate >= date1 && b.ReleaseDate <= date2).ToList();
        }
        public static int GetBookAmountByAuthor(AppContext db, string author)
        {
            return db.Books.Where(b => b.BookAuthor== author).Count();
        }
        public static int GetBookAmountByGenre(AppContext db, string genre)
        {
            return db.Books.Where(b => b.BookAuthor == genre).Count();
        }
        public static bool CheckBookByTitleAndAuthor(AppContext db, string title, string author)
        {
            return db.Books.Where(b => b.Title == title && b.BookAuthor == author).Count() > 0;
        }
        public static Book GetLatestBook(AppContext db)
        {
            return db.Books.OrderByDescending(b => b.ReleaseDate).FirstOrDefault();
        }
        public static List<Book> GetBooksInAlphabetOrder(AppContext db)
        {
            return db.Books.OrderBy(b => b.Title).ToList();
        }
        public static List<Book> GetBooksInDescendingReleaseDateOrder(AppContext db)
        {
            return db.Books.OrderByDescending(b => b.ReleaseDate).ToList();
        }
    }
}
