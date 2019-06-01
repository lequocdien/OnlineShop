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

        public int Login(string userName, string password)
        {
            var res = context.Users.SingleOrDefault(x => x.UserName == userName);
            if(res == null)
            {
                return 0;
            }
            else if(res.Password != password)
            {
                return -1;
            }
            else if(res.Status == false)
            {
                return -2;
            }
            return 1;
        }

        public User GetUserByUserName(string userName)
        {
            return context.Users.SingleOrDefault(x => x.UserName == userName);
        }
    }
}
