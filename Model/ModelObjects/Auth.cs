using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelObjects
{
    [KnownType(typeof(Leaf))]
    public class Auth : Leaf
    {
    }
}
