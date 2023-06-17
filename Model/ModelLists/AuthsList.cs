using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Model.ModelObjects;

namespace Model.ModelLists
{
    [CollectionDataContract]

    public class AuthsList : List<Auth>
    {
        public AuthsList() { }
        public AuthsList(IEnumerable<Auth> list) : base(list) { }
        public AuthsList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Auth>().ToList()) { }
    }
}
