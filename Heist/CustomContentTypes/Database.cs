using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heist
{
    public class Database
    {
        private Dictionary<String, DataTable> tables;

        public Database(Dictionary<String, DataTable> tables_)
        {
            tables = tables_;
        }

        public DataTable Get(String name)
        {
            return tables[name];
        }

    }
}
