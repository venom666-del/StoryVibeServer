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
            command.CommandText = "Select chaptersTbl.chapterID, chaptersTbl.datePublished, chaptersTbl.storyID, storiesTbl.header, chaptersTbl.topic, chaptersTbl.content, chaptersTbl.chapterNumber from chaptersTbl join storiesTbl on chaptersTbl.storyID = storiesTbl.storyID";
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
            return $"insert into chaptersTbl (storyID, topic, content, chapterNumber, datePublished) Values ({chapter.story.ID}, N'{chapter.topic}', N'{chapter.content}', '{chapter.chapterNumber}', '{chapter.datePublished}')";
        }
        protected override string CreateUpdateSQL(BaseEntity entity)
        {
            Chapter chapter = entity as Chapter;
            return $"update chaptersTbl set storyID=N'{chapter.story.ID}', topic=N'{chapter.topic}', content=N'{chapter.content}', chapterNumber='{chapter.chapterNumber}', datePublished='{chapter.datePublished}' where chapterID='{chapter.ID}'";
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
            chapter.datePublished = (string)reader["datePublished"];

            return chapter;
        }


        protected override BaseEntity newEntity()
        {
            Chapter chapter = new Chapter();
            return chapter;
        }
    }
}
