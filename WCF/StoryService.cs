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
        public int Delete(Story story)
        {
            StoriesDB storiesDB = new StoriesDB();
            storiesDB.Delete(story);
            return storiesDB.SaveChanges();
        }

        public int Insert(Story story)
        {
            StoriesDB storiesDB = new StoriesDB();
            storiesDB.Insert(story);
            return storiesDB.SaveChanges();
        }

        public StoriesList Select()
        {
            StoriesDB storiesDB = new StoriesDB();
            StoriesList stories = storiesDB.SelectStories();
            return stories;
        }

        public int Update(Story story)
        {
            StoriesDB storiesDB = new StoriesDB();
            storiesDB.Update(story);
            return storiesDB.SaveChanges();
        }
    }
}
