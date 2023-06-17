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
    public class StoriesDB : BaseDB
    {
        public StoriesDB()
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }


        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            Story story = new Story();
            return $"DELETE from storiesTbl where storyID={story.ID}";
        }

        protected override string CreateInsertSQL(BaseEntity entity)
        {
            Story story = new Story();
            return $"INSERT INTO storiesTbl(name, description, userID, ageBarrierID, categoryID, datePublished) VALUES(N'{story.name}', N'{story.description}', {story.user.ID}, {story.ageBarrier.ID}, {story.category.ID}, '{story.datePublished}')";
        }

        public StoriesList SelectStories()
        {
            command.CommandText = "SELECT storiesTbl.imageLink, storiesTbl.userID, storiesTbl.ageBarrierID, storiesTbl.categoryID, storiesTbl.storyID, storiesTbl.name, storiesTbl.description, UsersTbl.name as userName, ageBarriers.name as ageBarrierName, categories.name as categoryName, storiesTbl.datePublished From storiesTbl join UsersTbl on storiesTbl.userID = UsersTbl.userID join leavesTbl as ageBarriers on ageBarriers.leafID = ageBarrierID join leavesTbl as categories on categories.leafID = categoryID";
            StoriesList stories = new StoriesList(Select());
            return stories;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Story story = entity as Story;
            story.ID = (int)reader["storyID"];
            story.name = (string)reader["name"];
            story.description = (string)reader["description"];

            User user = new User();
            user.ID = (int)reader["userID"];
            user.name = (string)reader["userName"];
            story.user = user;

            AgeBarrier ageBarrier = new AgeBarrier();
            ageBarrier.ID = (int)reader["ageBarrierID"];
            ageBarrier.name = (string)reader["ageBarrierName"];
            story.ageBarrier = ageBarrier;

            Category category = new Category();
            category.ID = (int)reader["categoryID"];
            category.name = (string)reader["categoryName"];
            story.category = category;

            story.datePublished = (string)reader["datePublished"];
            story.imageLink = (string)reader["imageLink"];

            return story;
        }

        protected override string CreateUpdateSQL(BaseEntity entity)
        {
            Story story = new Story();
            return $"Update storiesTbl set name=N'{story.name}', description=N'{story.description}', userID={story.user.ID}, ageBarrier={story.ageBarrier.ID}, categoryID={story.category.ID}, datePublished={story.datePublished} where storyID={story.ID}";
        }

        protected override BaseEntity newEntity()
        {
            Story story = new Story();
            return story;
        }
    }
}
