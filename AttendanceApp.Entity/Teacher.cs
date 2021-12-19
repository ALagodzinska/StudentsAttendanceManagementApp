using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApp.Entity
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
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string Title { get { return $"{Name} {Surname}"; } }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Subject Course { get; set; }
        public string Email { get; set; }        
    }
}
