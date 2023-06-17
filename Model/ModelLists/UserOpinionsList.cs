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
    public class UserOpinionsList : List<UserOpinion>
    {
        public UserOpinionsList() { }
        public UserOpinionsList(IEnumerable<UserOpinion> list) : base(list) { }
        public UserOpinionsList(IEnumerable<BaseEntity> list)
            : base(list.Cast<UserOpinion>().ToList()) { }
    }
}
