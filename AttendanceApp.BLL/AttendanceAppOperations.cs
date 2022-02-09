using AttendanceApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
        public List<Student> GetAvailableStudentList(int reportId)
        {
            var listStudentAttendancy = DBOperations.GetStudentAttendancy(reportId);
            var listOfStudents = DBOperations.GetStudents();

            List<Student> notSelectedStudents = new List<Student>();

            foreach(var student in listOfStudents)
            {
                var studentAttendancy = listStudentAttendancy.FirstOrDefault(x => x.Student.Id == student.Id);
                if(studentAttendancy == null)
                {
                    notSelectedStudents.Add(student);
                }
            }

            return notSelectedStudents;
        }
        public void AddMissingStudents(int reportId)
        {
            var allStudents = GetAvailableStudentList(reportId);
            foreach(var student in allStudents)
            {
                var studAttendance = new StudentAttendancy
                {
                    Report = GetAttendanceReportById(reportId),
                    Student = student,
                    IsPresent = false
                };
                DBOperations.CreateStudentAttendancy(studAttendance, reportId);
            }
        }
        public void MarkAllStudentsPresent(int reportId)
        {
            var allStudents = DBOperations.GetStudentAttendancy(reportId);
            foreach (var studentAttendance in allStudents)
            {
                var studentAttendancy = new StudentAttendancy
                {
                    Id = studentAttendance.Id,
                    Report = studentAttendance.Report,
                    Student = studentAttendance.Student,
                    IsPresent = true
                };
                DBOperations.UpdateStudentAttendancy(studentAttendancy);
            }
        }
        public void MarkAllStudentsAbsent(int reportId)
        {
            var allStudents = DBOperations.GetStudentAttendancy(reportId);
            foreach (var studentAttendance in allStudents)
            {
                var studentAttendancy = new StudentAttendancy
                {
                    Id = studentAttendance.Id,
                    Report = studentAttendance.Report,
                    Student = studentAttendance.Student,
                    IsPresent = false
                };
                DBOperations.UpdateStudentAttendancy(studentAttendancy);
            }
        }
        public void ChangeStudentPresent(int studAtId)
        {
            var studentAttendance = DBOperations.GetStudentAttendancyById(studAtId);
            if(studentAttendance.IsPresent == true)
            {
                studentAttendance.IsPresent = false;
            }
            else
            {
                studentAttendance.IsPresent = true;
            }
            DBOperations.UpdateStudentAttendancy(studentAttendance);
        }
    }    
}
