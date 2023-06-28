using Model;
using Model.ModelLists;
using Model.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoriesDB : BaseDB
    {
        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override string CreateInsertSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public CategoryGroupList SelectCategories()
        {
            command.CommandText = "select storiesTbl.storyID as storyID, storiesTbl.header as storyHeader, leavesTbl.leafID as categoryID, leavesTbl.name as categoryName from categoriesToStoryTbl join storiesTbl on storiesTbl.storyID = categoriesToStoryTbl.StoryID join leavesTbl on leavesTbl.leafID = categoriesToStoryTbl.categoryID";
            CategoryGroupList categories = new CategoryGroupList(Select());
            return categories;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            categoryGroup categories = entity as categoryGroup;

            Story story = new Story();
            story.ID = (int)reader["storyID"];
            story.header = (string)reader["storyHeader"];
            categories.story = story;

            Category category = new Category();
            category.ID = (int)reader["categoryID"];
            category.name = (string)reader["categoryName"];
            categories.category = category;

            return categories;
        }

        protected override string CreateUpdateSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override BaseEntity newEntity()
        {
            categoryGroup category = new categoryGroup();
            return category;
        }
    }
}
