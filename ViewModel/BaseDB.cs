using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.ModelObjects;

namespace ViewModel
{
    public abstract class BaseDB
    {
        protected string connectionString = "";
        protected SqlConnection connection;
        protected SqlCommand command;
        protected SqlDataReader reader;

        protected abstract BaseEntity newEntity();
        protected abstract BaseEntity CreateModel(BaseEntity entity);

        protected List<ChangeEntity> inserted = new List<ChangeEntity>();
        protected List<ChangeEntity> deleted = new List<ChangeEntity>();
        protected List<ChangeEntity> updated = new List<ChangeEntity>();
        protected abstract string CreateInsertSQL(BaseEntity entity);
        protected abstract string CreateUpdateSQL(BaseEntity entity);
        protected abstract string CreateDeleteSQL(BaseEntity entity);
        public BaseDB()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\StoryVibe\StoryVibeServer\ViewModel\StoryVibeDB.mdf;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
        }

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(entity, this.CreateInsertSQL));
            }
        }

        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(entity, this.CreateUpdateSQL));
            }
        }

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(entity, this.CreateDeleteSQL));
            }
        }

        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BaseEntity entity = newEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public int SaveChanges()
        {
            SqlCommand command = new SqlCommand();
            int record = 0;
            try
            {
                command.Connection = this.connection;
                connection.Open();
                foreach (var item in inserted)
                {
                    command.CommandText = item.CreateSql(item.Entity);
                    record += command.ExecuteNonQuery();

                    if (item.DoINeedIT)
                    {
                        command.CommandText = "select @@Identity";
                        int.TryParse(command.ExecuteScalar().ToString(), out int lastID);
                        item.Entity.ID = lastID;
                    }
                }
                foreach (var item in updated)
                {
                    command.CommandText = item.CreateSql(item.Entity);
                    record += command.ExecuteNonQuery();
                }
                foreach (var item in deleted)
                {
                    command.CommandText = item.CreateSql(item.Entity);
                    record += command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                inserted.Clear();
                updated.Clear();
                deleted.Clear();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return record;
        }
    }
}
