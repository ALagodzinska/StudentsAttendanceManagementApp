using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApp.UI
{
    public enum Subject
    {
        Art,
        Biology,
        Economics,
        English,
        French,
        Geography,
        History,
        Literature,
        Math,
        Psychology,
        Science,
        Sport
    }
    public class TeacherModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get { return $"{Name} {Surname}"; } }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public Subject Course { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
