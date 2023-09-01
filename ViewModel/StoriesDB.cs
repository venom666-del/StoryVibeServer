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
            return $"DELETE from chaptersTbl where storyID={story.ID}; DELETE from storiesTbl where storyID={story.ID}";
        }

        protected override string CreateInsertSQL(BaseEntity entity)
        {
            Story story = new Story();
            return $"INSERT INTO storiesTbl(header, description, userID, ageBarrierID, datePublished, languageID, statusID, imageLink, price, views) VALUES(N'{story.header}', N'{story.description}', {story.user.ID}, {story.ageBarrier.ID}, '{story.datePublished}', '{story.language.ID}', '{story.status.ID}', '{story.imageLink}', '{story.price}', 'NULL')";
        }

        public ServedFullStory SelectStories()
        {
            command.CommandText = "SELECT storiesTbl.storyID, storiesTbl.views, storiesTbl.header, storiesTbl.description, storiesTbl.userID, UsersTbl.name as userName, storiesTbl.ageBarrierID, ageBarriers.name as ageBarrierName, storiesTbl.datePublished, storiesTbl.languageID, languages.name as languageName, storiesTbl.statusID, statuses.name as statusName, storiesTbl.imageLink, storiesTbl.price From storiesTbl join UsersTbl on storiesTbl.userID = UsersTbl.userID join leavesTbl as ageBarriers on ageBarriers.leafID = ageBarrierID join leavesTbl as languages on languages.leafID = languageID join leavesTbl as statuses on statuses.leafID = storiesTbl.statusID";
            StoriesList stories = new StoriesList(Select());
            CategoriesDB categoriesDB = new CategoriesDB();
            CategoryGroupList categoryGroupList = categoriesDB.SelectCategories();
            ServedFullStory fullStory = new ServedFullStory();
            fullStory.stories = stories;
            fullStory.categoryGroup = categoryGroupList;
            return fullStory;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Story story = entity as Story;
            story.ID = (int)reader["storyID"];
            story.header = (string)reader["header"];
            story.description = (string)reader["description"];

            User user = new User();
            user.ID = (int)reader["userID"];
            user.name = (string)reader["userName"];
            story.user = user;

            AgeBarrier ageBarrier = new AgeBarrier();
            ageBarrier.ID = (int)reader["ageBarrierID"];
            ageBarrier.name = (string)reader["ageBarrierName"];
            story.ageBarrier = ageBarrier;

            Language language = new Language();
            language.ID = (int)reader["languageID"];
            language.name = (string)reader["languageName"];
            story.language = language;

            Status status = new Status();
            status.ID = (int)reader["statusID"];
            status.name = (string)reader["statusName"];
            story.status = status;

            story.datePublished = (string)reader["datePublished"];
            story.imageLink = (string)reader["imageLink"];
            story.price = (double)reader["price"];
            story.views = (int)reader["views"];

            return story;
        }

        protected override string CreateUpdateSQL(BaseEntity entity)
        {
            Story story = entity as Story;
            return $"Update storiesTbl set header=N'{story.header}', views='{story.views}', description=N'{story.description}', userID={story.user.ID}, ageBarrierID={story.ageBarrier.ID}, datePublished={story.datePublished}, languageID={story.language.ID}, statusID={story.status.ID}, imageLink='{story.imageLink}', price={story.price} where storyID={story.ID}";
        }

        protected override BaseEntity newEntity()
        {
            Story story = new Story();
            return story;
        }
    }
}
