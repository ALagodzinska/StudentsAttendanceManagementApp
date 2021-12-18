using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApp.UI
{
    public class TeacherModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get { return $"{Name} {Surname}"; } }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
    }
}
