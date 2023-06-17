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

    public class ShopsList : List<Shop>
    {
        public ShopsList() { }
        public ShopsList(IEnumerable<Shop> list) : base(list) { }
        public ShopsList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Shop>().ToList()) { }
    }
}
