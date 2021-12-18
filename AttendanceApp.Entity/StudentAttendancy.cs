using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApp.Entity
{
    public class StudentAttendancy
    {
        [Key]
        public int Id { get; set; }
        public AttendanceReport Report { get; set; }
        public Student Student { get; set; }
        public bool IsPresent { get; set; }
    }
}
