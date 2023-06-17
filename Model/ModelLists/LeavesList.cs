using Model.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelLists
{
    [CollectionDataContract]

    public class LeavesList : List<Leaf>
    {
        public LeavesList() { }
        public LeavesList(IEnumerable<Leaf> list) : base(list) { }
        public LeavesList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Leaf>().ToList()) { }
    }
}
