using Model;
using Model.ModelLists;
using Model.ModelObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        public UserDB()
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }

        public UsersList SelectAll()
        {
            command.CommandText = "SELECT UsersTbl.userID, UsersTbl.name, UsersTbl.email, UsersTbl.password, UsersTbl.birthDate, UsersTbl.creationDate, leavesTbl.name as AuthName, UsersTbl.authID from UsersTbl join leavesTbl on UsersTbl.authID = leavesTbl.leafID";
            UsersList users = new UsersList(base.Select());
            return users;
        }

        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override string CreateInsertSQL(BaseEntity entity)
        {
            User user = entity as User;
            return $"insert into UsersTbl (name, email, password, authID, birthDate, creationDate) Values (N'{user.name}', N'{user.email}', N'{user.password}', '{user.auth.ID}', '{user.birthDate}', '{user.creationDate}')";
        }
        protected override string CreateUpdateSQL(BaseEntity entity)
        {
            User user = entity as User;
            return $"update UsersTbl set name=N'{user.name}', email=N'{user.email}', password=N'{user.password}', authID='{user.auth.ID}', birthDate='{user.birthDate}', creationDate='{user.creationDate}' where userID='{user.ID}'";
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.ID = (int)reader["userID"];
            user.name = (string)reader["name"];
            user.email = (string)reader["email"];
            user.password = (string)reader["password"];
            user.birthDate = (string)reader["birthDate"];
            user.creationDate = (string)reader["creationDate"];

            Auth auth = new Auth();
            auth.ID = (int)reader["authID"];
            auth.name = (string)reader["AuthName"];
            user.auth = auth;

            return user;
        }


        protected override BaseEntity newEntity()
        {
            User user = new User();
            return user;
        }
    }
}
