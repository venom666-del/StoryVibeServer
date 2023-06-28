using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelObjects
{
    public class Purchase : BaseEntity
    {
        public User user { get; set; }
        public Story story { get; set; }
        public double price { get; set; }
        public string purchaseDate { get; set; }
    }
}
