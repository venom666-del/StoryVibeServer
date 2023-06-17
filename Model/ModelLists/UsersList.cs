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
    public class UsersList : List<User>
    {
        public UsersList() { }
        public UsersList(IEnumerable<User> list) : base(list) { }
        public UsersList(IEnumerable<BaseEntity> list)
            : base(list.Cast<User>().ToList()) { }
    }
}
