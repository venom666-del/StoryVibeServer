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

    public class AgeBarriersList : List<AgeBarrier>
    {
        public AgeBarriersList() { }
        public AgeBarriersList(IEnumerable<AgeBarrier> list) : base(list) { }
        public AgeBarriersList(IEnumerable<BaseEntity> list)
            : base(list.Cast<AgeBarrier>().ToList()) { }
    }
}
