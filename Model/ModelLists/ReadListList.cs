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

    public class ReadListList : List<ReadList>
    {
        public ReadListList() { }
        public ReadListList(IEnumerable<ReadList> list) : base(list) { }
        public ReadListList(IEnumerable<BaseEntity> list)
            : base(list.Cast<ReadList>().ToList()) { }
    }
}
