using AttendanceApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApp.BLL
{
    interface IAttendanceAppOperations
    {
        public User GetUserByCreds (User user);
        public Teacher GetTeacherById(int id);
        public Student GetStudentById(int id);
        public AttendanceReport GetAttendanceReportById(int id);
        public List<Student> GetAvailableStudentList(int reportId);
    }
}
