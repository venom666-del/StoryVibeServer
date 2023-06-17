using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelObjects
{
    public class Leaf : BaseEntity
    {
        public string name { get; set; }
        public LeafType Type { get; set; }
    }
}
