using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApp.Entity
{
    public class AttendanceReport
    {
        [Key]
        public int ReportID { get; set; }
        public virtual Teacher Teacher { get; set; }
        public DateTime? Date { get; set; }
    }
}
