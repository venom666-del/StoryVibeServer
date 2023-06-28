using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelObjects
{
    public class Follow : BaseEntity
    {
        public User follower { get; set; }
        public User target { get; set; }
        public string followedDate { get; set; }
    }
}
