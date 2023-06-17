using Model.ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelLists
{
    [CollectionDataContract]

    public class ChaptersList : List<Chapter>
    {
        public ChaptersList() { }
        public ChaptersList(IEnumerable<Chapter> list) : base(list) { }
        public ChaptersList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Chapter>().ToList()) { }
    }
}
