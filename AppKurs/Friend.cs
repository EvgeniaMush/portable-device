using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppKurs
{
    [Table("Friends")]
    public class Friend
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string TextArea { get; set; }
        public string date { get; set; }
     
    }
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }

}
