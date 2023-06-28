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
    public class LeafService : ILeafService
    {
        public LeavesList selectLeaves(Enums.leaves leaftype)
        {
            LeafDB leafDB = new LeafDB();
            return leafDB.SelectLeaf(leaftype);
        }
    }
}
