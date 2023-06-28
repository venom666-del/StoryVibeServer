using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelObjects
{
    public class categoryGroup : BaseEntity
    {
        public Story story { get; set; }
        public Category category { get; set; }
    }
}
