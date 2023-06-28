using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelObjects
{
    public class Story : BaseEntity
    {
        public string header { get; set; }
        public string description { get; set; }
        public User user { get; set; }
        public AgeBarrier ageBarrier { get; set; }
        public Category category { get; set; }
        public string datePublished { get; set; }
        public Language language { get; set; }
        public Status status { get; set; }
        public string imageLink { get; set; }
        public double price { get; set; }
    }
}
