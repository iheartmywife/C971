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
    [Table("Courses")]
    public class Course
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("ID")]
        public int ID { get; set; }

        [Column("TermID")]       
        public int TermID { get; set; }

        [Column("Name")]
        public string CourseName { get; set; }

        [Column("CourseStart")]
        public DateTime CourseStartDate { get; set; }

        [Column("CourseEnd")]
        public DateTime CourseEndDate { get; set; }

        [Column("Status")]
        public string Status { get; set; }


        [Column("Instructor")]
        public string CIName {  get; set; }

        [Column("Phone")]
        public string CIPhone { get; set; }

        [Column("CI_Email")]
        public string CIEmail { get; set; }

        [Column("OA")]
        public string OA { get; set; }

        [Column("OA_Due")]
        public DateTime OADue {  get; set; }

        [Column("PA")]
        public string PA { get; set; }

        [Column("PA_Due")]
        public DateTime PADue { get; set; }

        [Column("Course_Notes")]
        public string notes { get; set; }
    }
}
