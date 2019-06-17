using MvcGroupApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGroupApp.Helper
{
    public class AccountControl
    {
        public static AppDbContext db = new AppDbContext();

        /// <summary>
        /// Tüm kullanıcıların listesini getir
        /// </summary>
        /// <returns></returns>
        public static List<User> GetUserList()
        {
            var userList = new List<User>();
            userList = db.Users.ToList();
            return userList;
        }

        /// <summary>
        /// Gelen kullanıcı bilgileri kayıtlı mı?
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool UserControl(string email, string password)
        {
            bool IsAuthorized = false;

            foreach (User item in GetUserList())
            {
                if (email == item.UserMail && password == item.UserPassword)
                    IsAuthorized = true;
            }

            return IsAuthorized;
        }
    }
}