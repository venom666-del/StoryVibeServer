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

    public class ShopsList : List<Purchase>
    {
        public ShopsList() { }
        public ShopsList(IEnumerable<Purchase> list) : base(list) { }
        public ShopsList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Purchase>().ToList()) { }
    }
}
