using EFPractice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractice.Repositories
{
    public static class UserRepository
    {
        public static User SelectById(AppContext db, int id)
        {           
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
        public static List<User> SelectAll(AppContext db)
        {
            return db.Users.ToList();
        }
        public static void AddUser(AppContext db, User user)
        {
            db.Add(user);
        }
        public static void RemoveUser(AppContext db, User user)
        {
            db.Remove(user);
        }
        public static void UpdateUserNameById(AppContext db, int id, string name)
        {
            db.Users.FirstOrDefault(u => u.Id == id).Name = name;
        }
        public static void GetBook(AppContext db, User user, Book book)
        {
            user.OwnedBooks?.Add(book);         
        }
        public static void TakeBookAway(AppContext db, User user, Book book)
        {            
            user.OwnedBooks.Remove(book);
        }
        public static bool CheckIfUserOwnsBook(AppContext db, User user, Book book)
        {
            return db.Users.Where(u => u.OwnedBooks.Contains(book)).Count() > 0;
        }
        public static int CountOwnedBooks(User user)
        {
            return user.OwnedBooks.Count();
        }
    }
}
