using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelObjects
{
    public class User : BaseEntity
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Auth auth { get; set; }
        public string birthDate { get; set; }
        public string creationDate { get; set; }
    }
}
