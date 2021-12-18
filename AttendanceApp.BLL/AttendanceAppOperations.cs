using AttendanceApp.Entity;
using System;
using System.Linq;

namespace AttendanceApp.BLL
{
    public class AttendanceAppOperations : IAttendanceAppOperations
    {
        public User GetUserByCreds(User user)
        {
            var userList = DBOperations.GetUsers();
            var foundUser = userList.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            return foundUser;
        }
        public Teacher GetTeacherById(int id)
        {
            var teacherList = DBOperations.GetTeachers();
            var teacherById = teacherList.FirstOrDefault(x => x.Id == id);
            return teacherById;
        }
        public Student GetStudentById(int id)
        {
            var studentList = DBOperations.GetStudents();
            var studentById = studentList.FirstOrDefault(x => x.Id == id);
            return studentById;
        }
        public AttendanceReport GetAttendanceReportById(int id)
        {
            var attendanceReportList = DBOperations.GetAttendanceReport();
            var reportById = attendanceReportList.FirstOrDefault(x => x.ReportID == id);
            return reportById;
        }
        //public bool CheckIfContainsStudent(int id)
        //{
        //    var studentReport = DBOperations.GetAllFromStudentAttendancy(id);
        //    if (studentReport.Contains() == true)
        //    {
        //        Console.WriteLine("Item exists!");
        //    }
        //}       

    }    
}
