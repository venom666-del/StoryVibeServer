using Model.ModelLists;
using Model.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        UsersList Select();

        [OperationContract]
        int Insert(User user);

        [OperationContract]
        int Update(User user);
    }
}
