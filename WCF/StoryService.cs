using Model.ModelLists;
using Model.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace WCF
{
    public class StoryService : IStoryService
    {
        //stories
        public ServedFullStory SelectStories()
        {
            StoriesDB storiesDB = new StoriesDB();
            ServedFullStory stories = storiesDB.SelectStories();
            return stories;
        }
        public int AddNewStory(Story story)
        {
            StoriesDB storiesDB = new StoriesDB();
            storiesDB.Insert(story);
            return storiesDB.SaveChanges();
        }
        public int UpdateStory(Story story)
        {
            StoriesDB storiesDB = new StoriesDB();
            storiesDB.Update(story);
            return storiesDB.SaveChanges();
        }
        public int DeleteStory(Story story)
        {
            StoriesDB storiesDB = new StoriesDB();
            storiesDB.Delete(story);
            return storiesDB.SaveChanges();
        }

        //chapters
        public ChaptersList SelectChapters()
        {
            ChapterDB chapterDB = new ChapterDB();
            ChaptersList chapters = chapterDB.SelectAll();
            return chapters;
        }
        public int AddNewChapter(Chapter chapter)
        {
            ChapterDB chapterDB = new ChapterDB();
            chapterDB.Insert(chapter);
            return chapterDB.SaveChanges();
        }
        public int UpdateChapter(Chapter chapter)
        {
            ChapterDB chapterDB = new ChapterDB();
            chapterDB.Update(chapter);
            return chapterDB.SaveChanges();
        }
        public int DeleteChapter(Chapter chapter)
        {
            ChapterDB chapterDB = new ChapterDB();
            chapterDB.Delete(chapter);
            return chapterDB.SaveChanges();
        }
    }
}
