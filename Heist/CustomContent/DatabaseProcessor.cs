using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using System.Data.SQLite;
using System.Data;
using System.Reflection;
using GameLogic.Model;
using GameLogic.Model.Static;

namespace CustomContent
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to apply custom processing to content data, converting an object of
    /// type TInput to TOutput. The input and output types may be the same if
    /// the processor wishes to alter data without changing its type.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    ///
    /// TODO: change the ContentProcessor attribute to specify the correct
    /// display name for this processor.
    /// </summary>
    [ContentProcessor(DisplayName = "SQLite Database")]
    public class DatabaseProcessor: ContentProcessor<SQLiteConnection, StaticData>
    {  
        public DataTable Query(SQLiteConnection conn, String sql)
        {
            SQLiteCommand q = new SQLiteCommand(conn);
            q.CommandText = sql;
            SQLiteDataReader read = q.ExecuteReader();
            DataTable res = new DataTable();
            res.Load(read);
            read.Close();
            
            return res;
        }

        private Dictionary<String, T> ReadTable<T>(SQLiteConnection conn, String tblName, int keyCol)
        {
            Dictionary<string, T> res = new Dictionary<string, T>();
            Type type = typeof(T);

            String[] fields = new String[] {"name","texName","accel"};
            foreach (PropertyInfo p in type.GetProperties())
            {
                //fields += "`" + p.Name + "`,";
            }

            //fields = fields.Remove(fields.Length - 1);
            String fieldStr = "";
            for (int i = 0; i < fields.Length; i++ )
            {
                if (i != 0)
                    fieldStr += ",";

                fieldStr += fields[i];
            }
            DataTable tbl = Query(conn, "SELECT " + fieldStr + " FROM " + tblName);

            foreach (DataRow row in tbl.Rows)
            {
                var vals = row.ItemArray;

                var name = (String)vals[keyCol];
                
                T obj = (T)Activator.CreateInstance(type, vals);

                res.Add(name, obj);
            }

            return res;
        }

        public override StaticData Process(SQLiteConnection input, ContentProcessorContext context)
        {
            input.Open();
            var test = ReadTable<TestEntityFactory>(input, "TestEntity", 0);
            input.Close();
            test.Add("rer", new TestEntityFactory("b","b",new Decimal(.1)));

            return new StaticData(test);
        }
    }
}