using Model.ModelLists;
using Model.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ViewModel;

namespace WCF
{
    public class UserService : IUserService
    {
        public int Insert(User user)
        {
            UserDB userDB = new UserDB();
            userDB.Insert(user);
            return userDB.SaveChanges();
        }

        public UsersList Select()
        {
            UserDB userDB = new UserDB();
            UsersList users = userDB.SelectAll();
            return users;
        }

        public int Update(User user)
        {
            UserDB userDB = new UserDB();
            userDB.Update(user);
            return userDB.SaveChanges();
        }
    }
}
