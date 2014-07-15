using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomContent
{
    [ContentImporter(".dat", DefaultProcessor = "DatabaseProcessor",
         DisplayName = "SQLite Database")]
    class DatabaseImporter : ContentImporter<SQLiteConnection>
    {
        public override SQLiteConnection Import(string filename, ContentImporterContext context)
        {
            String connOps = "Data Source=" + filename;
            return new SQLiteConnection(connOps);
        }
    }
}
