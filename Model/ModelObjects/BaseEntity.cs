using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public delegate string CreateSQL(BaseEntity entity);
    public class BaseEntity
    {
        private int Id;
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
