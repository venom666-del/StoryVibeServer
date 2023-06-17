using Model;
using Model.ModelLists;
using Model.ModelObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LeafDB : BaseDB
    {
        public LeafDB()
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }

        public LeavesList SelectLeaf(Enums.leaves leaf)
        {
            LeavesList leaves = new LeavesList();
            switch (leaf)
            {
                case Enums.leaves.all:
                    command.CommandText = "SELECT leavesTbl.name as leafName, leavesTbl.leafID, leafTypeTbl.name as leafTypeName From leavesTbl join leafTypeTbl on leavesTbl.typeID = leafTypeTbl.typeID";
                    leaves = new LeavesList(base.Select());
                    break;
                default:
                    command.CommandText = $"SELECT leavesTbl.name as leafName, leavesTbl.leafID, leafTypeTbl.name as leafTypeName From leavesTbl join leafTypeTbl on leavesTbl.typeID = leafTypeTbl.typeID where leavesTbl.typeID={(int)leaf}";
                    leaves = new LeavesList(base.Select());
                    break;
            }
            return leaves;
        }

        protected override string CreateDeleteSQL(BaseEntity entity)
        {
            Leaf leaf = entity as Leaf;
            return $"DELETE leavesTbl where leafID={leaf.ID}";
        }

        protected override string CreateInsertSQL(BaseEntity entity)
        {
            Leaf leaf = entity as Leaf;
            return $"INSERT INTO leavesTbl(name, typeID) values({leaf.name}, {leaf.Type.ID})";
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Leaf leaf = entity as Leaf;
            leaf.ID = (int)reader["leafID"];
            leaf.name = (string)reader["leafName"];
            LeafType type = new LeafType();
            type.ID = (int)reader["typeID"];
            type.name = (string)reader["leafTypeName"];
            leaf.Type = type;
            return leaf;
        }

        protected override string CreateUpdateSQL(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override BaseEntity newEntity()
        {
            Leaf leaf = new Leaf();
            return leaf;
        }
    }
}
