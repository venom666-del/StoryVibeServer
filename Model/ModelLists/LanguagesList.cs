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
    public class LanguagesList : List<Language>
    {
        public LanguagesList() { }
        public LanguagesList(IEnumerable<Language> list) : base(list) { }
        public LanguagesList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Language>().ToList()) { }
    }
}
