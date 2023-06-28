using Model.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelLists
{
    [CollectionDataContract]
    public class CategoryGroupList : List<categoryGroup>
    {
        public CategoryGroupList() { }
        public CategoryGroupList(IEnumerable<categoryGroup> list) : base(list) { }
        public CategoryGroupList(IEnumerable<BaseEntity> list)
            : base(list.Cast<categoryGroup>().ToList()) { }
    }
}
