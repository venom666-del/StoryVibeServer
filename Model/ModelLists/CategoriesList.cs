using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Model.ModelObjects;

namespace Model.ModelLists
{
    [CollectionDataContract]

    public class CategoriesList : List<Category>
    {
        public CategoriesList() { }
        public CategoriesList(IEnumerable<Category> list) : base(list) { }
        public CategoriesList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Category>().ToList()) { }
    }
}
