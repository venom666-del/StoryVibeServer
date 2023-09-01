using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelObjects
{
    public class Chapter : BaseEntity
    {
        public Story story { get; set; }
        public string topic { get; set; }
        public string content { get; set; }
        public int chapterNumber { get; set; }
        public string datePublished { get; set; }
    }
}
