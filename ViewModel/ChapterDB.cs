using Model.ModelLists;
using Model.ModelObjects;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ChapterDB : BaseDB
    {
        public ChapterDB()
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }

        public ChaptersList SelectAll()
        {
            command.CommandText = "Select chaptersTbl.chapterID, chaptersTbl.storyID, storiesTbl.header, chaptersTbl.topic, chaptersTbl.content, chaptersTbl.chapterNumber from chaptersTbl join storiesTbl on chaptersTbl.storyID = storiesTbl.storyID";
            ChaptersList chapters = new ChaptersList(base.Select());
            return chapters;
        }

        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            Chapter chapter = entity as Chapter;
            return $"Delete from chaptersTbl where chapterID='{chapter.ID}'";
        }

        protected override string CreateInsertSQL(BaseEntity entity)
        {
            Chapter chapter = entity as Chapter;
            return $"insert into chaptersTbl (storyID, topic, content, chapterNumber) Values ({chapter.story.ID}, N'{chapter.topic}', N'{chapter.content}', '{chapter.chapterNumber}')";
        }
        protected override string CreateUpdateSQL(BaseEntity entity)
        {
            User user = entity as User;
            return $"update UsersTbl set name=N'{user.name}', email=N'{user.email}', password=N'{user.password}', authID='{user.auth.ID}', birthDate='{user.birthDate}', creationDate='{user.creationDate}' where userID='{user.ID}'";
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Chapter chapter = entity as Chapter;

            Story story = new Story();
            story.ID = (int)reader["storyID"];
            story.header = (string)reader["header"];
            chapter.story = story;

            chapter.topic = (string)reader["topic"];
            chapter.content = (string)reader["content"];
            chapter.chapterNumber = (int)reader["chapterNumber"];

            return chapter;
        }


        protected override BaseEntity newEntity()
        {
            Chapter chapter = new Chapter();
            return chapter;
        }
    }
}
