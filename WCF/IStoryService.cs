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
        [OperationContract]
        StoriesList Select();

        [OperationContract]
        int Insert(Story story);

        [OperationContract]
        int Update(Story story);

        [OperationContract]
        int Delete(Story story);
    }
}
