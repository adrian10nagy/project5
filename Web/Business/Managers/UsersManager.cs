using DAL.Entities;
using DAL.SDK;
using System.Collections.Generic;

namespace Business.Managers
{
    public static class UsersManager
    {
        public static List<User> GetAll()
        {
            return Kit.Instance.Users.GetAll();
        }

        public static User ValidateLogin(string email, string password)
        {
            var user = Kit.Instance.Users.GetUserByEmailPass(email, password);

            return user;
        }

        public static User GetByEmail(string email)
        {
            var user = Kit.Instance.Users.GetUserByEmail(email);

            return user;
        }

        public static void Insert(User user)
        {
            Kit.Instance.Users.Insert(user);
        }
    }
}
