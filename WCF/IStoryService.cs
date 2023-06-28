using Model.ModelLists;
using Model.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    [ServiceContract]
    public interface IStoryService
    {
        //stories
        [OperationContract]
        ServedFullStory SelectStories();

        [OperationContract]
        int AddNewStory(Story story);

        [OperationContract]
        int UpdateStory(Story story);

        [OperationContract]
        int DeleteStory(Story story);

        //chapters
        [OperationContract]
        ChaptersList SelectChapters();

        [OperationContract]
        int AddNewChapter(Chapter chapter);

        [OperationContract]
        int UpdateChapter(Chapter chapter);

        [OperationContract]
        int DeleteChapter(Chapter chapter);
    }
}
