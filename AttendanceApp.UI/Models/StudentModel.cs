using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApp.UI
{
    public enum StudentGroup
    {
        A01,
        A02,
        B01,
        B02,
        C01
    }
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get { return $"{Name} {Surname}"; } }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }        
        public StudentGroup StudentGroupID { get; set; }
    }
}
