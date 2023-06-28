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
    public interface ILeafService
    {
        [OperationContract]

        LeavesList selectLeaves(Enums.leaves leaftype);
    }
}
