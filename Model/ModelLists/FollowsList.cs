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

    public class FollowsList : List<Follow>
    {
        public FollowsList() { }
        public FollowsList(IEnumerable<Follow> list) : base(list) { }
        public FollowsList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Follow>().ToList()) { }
    }
}
