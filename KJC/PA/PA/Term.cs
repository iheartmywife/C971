using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColumnAttribute = SQLite.ColumnAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace PA
{
    [Table("Terms")]
    public class Term
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("ID")]
        public int ID { get; set; }
        
        [Column("Term_Name")]
        public string TermName { get; set; }
        
        [Column("Start_Date")]
        public DateTime StartDate { get; set; }

        [Column("End_Date")]
        public DateTime EndDate { get; set; }
    }
}
