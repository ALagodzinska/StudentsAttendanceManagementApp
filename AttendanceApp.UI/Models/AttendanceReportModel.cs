using AttendanceApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApp.UI
{
    public class AttendanceReportModel
    {
        [Key]
        public int ReportID { get; set; }
        [Required] 
        public Teacher Teachers { get; set; }
        [Required]
        public DateTime? Date { get; set; }
    }
}
