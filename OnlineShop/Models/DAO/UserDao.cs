using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class UserDao
    {
        OnlineShopDbContext context = null;
        public UserDao()
        {
            context = new OnlineShopDbContext();
        }

        public long Insert(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
            return entity.ID;
        }

        public bool Login(string userName, string password)
        {
            var res = context.Users.Count(x => x.UserName == userName && x.Password == password);
            if(res > 0)
            {
                return true;
            }
            return false;
        }

        public User GetUserByUserName(string userName)
        {
            return context.Users.SingleOrDefault(x => x.UserName == userName);
        }
    }
}
