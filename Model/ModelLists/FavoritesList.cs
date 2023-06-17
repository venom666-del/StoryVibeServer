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

    public class FavoritesList : List<Favorite>
    {
        public FavoritesList() { }
        public FavoritesList(IEnumerable<Favorite> list) : base(list) { }
        public FavoritesList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Favorite>().ToList()) { }
    }
}
