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

    public class StoriesList : List<Story>
    {
        public StoriesList() { }
        public StoriesList(IEnumerable<Story> list) : base(list) { }
        public StoriesList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Story>().ToList()) { }
    }
}
