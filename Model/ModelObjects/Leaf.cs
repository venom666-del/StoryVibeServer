using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelObjects
{
    [KnownType(typeof(Auth))]
    [KnownType(typeof(Category))]
    [KnownType(typeof(Language))]
    [KnownType(typeof(Status))]
    [KnownType(typeof(AgeBarrier))]
    public class Leaf : BaseEntity
    {
        public string name { get; set; }
        public LeafType Type { get; set; }
    }
}
