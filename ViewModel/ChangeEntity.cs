using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ChangeEntity
    {
        private BaseEntity entity;
        private CreateSQL createSql;
        private bool doINeedIT;

        public BaseEntity Entity
        {
            get { return entity; }
        }
        public CreateSQL CreateSql
        {
            get { return createSql; }
        }
        public bool DoINeedIT
        {
            get { return doINeedIT; }
        }

        public ChangeEntity(BaseEntity entity, CreateSQL createSql)
        {
            this.entity = entity;
            this.createSql = createSql;
        }

        public ChangeEntity(BaseEntity entity, CreateSQL createSql, bool doINeedIT)
        {
            this.entity = entity;
            this.createSql = createSql;
            this.doINeedIT = doINeedIT;
        }
    }
}
