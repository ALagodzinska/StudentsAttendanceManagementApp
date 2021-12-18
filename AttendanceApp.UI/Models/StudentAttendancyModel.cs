using AttendanceApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApp.UI
{
    public class StudentAttendancyModel
    {
        public int Id { get; set; }
        [Required]
        public Student Student  { get; set; }
        public int ReportID { get; set; }
        public bool IsPresent { get; set; }
    }
}
