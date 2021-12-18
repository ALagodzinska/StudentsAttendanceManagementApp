using AttendanceApp.BLL.Context;
using AttendanceApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApp.BLL
{
    public class DBOperations
    {
        public static void CreateDbIfNotExsists() 
        {
            using (var context = new AttendanceAppDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
        public static List<Student> GetStudents()
        {
            var students = new List<Student>();
            using (var Context = new AttendanceAppDbContext())
            {
                students = Context.Students.ToList();
            }

            return students;
        }
        public static List<User> GetUsers()
        {
            var users = new List<User>();
            using (var Context = new AttendanceAppDbContext())
            {
                users = Context.Users.ToList();
            }

            return users;
        }
        public static List<Teacher> GetTeachers()
        {
            var teachers = new List<Teacher>();
            using (var Context = new AttendanceAppDbContext())
            {
                teachers = Context.Teachers.ToList();
            }

            return teachers;
        }
        public static List<AttendanceReport> GetAttendanceReport()
        {
            using (var Context = new AttendanceAppDbContext())
            {
                var reports = Context.AttendanceReports.Include(x => x.Teacher).ToList();
                return reports;
            }            
        }
        public static List<StudentAttendancy> GetStudentAttendancy(int id)
        {
            using (var Context = new AttendanceAppDbContext())
            {
                var students = Context.StudentAttendancy
                    .Include(x => x.Report)
                    .Include(x => x.Student)
                    .Where(x => x.Report.ReportID == id).ToList();
                return students;
            }
        }
        public static void CreateStudentAttendancy(StudentAttendancy studentAttendancy, int id)
        {
            using (var Context = new AttendanceAppDbContext())
            {
                var reportRecord = Context.AttendanceReports.FirstOrDefault(x => x.ReportID == id);
                var studentRecord = Context.Students.FirstOrDefault(x => x.Id == studentAttendancy.Student.Id);
                var newStudent = new StudentAttendancy()
                {
                    Report = reportRecord,
                    Student = studentRecord,
                    IsPresent = studentAttendancy.IsPresent
                };
                Context.StudentAttendancy.Add(newStudent);
                Context.SaveChanges();
            }
        }
        public static void CreateAttendanceReport(AttendanceReport report)
        {
            using (var Context = new AttendanceAppDbContext())
            {
                var teacherRecord = Context.Teachers.FirstOrDefault(x => x.Id == report.Teacher.Id);
                var newReport = new AttendanceReport()
                {
                    Teacher = teacherRecord,
                    Date = report.Date
                };
                Context.AttendanceReports.Add(newReport);
                Context.SaveChanges();
            }
        }
        public static void UpdateAttendanceReport(AttendanceReport report, int id)
        {
            using (var Context = new AttendanceAppDbContext())
            {
                var updateReport = Context.AttendanceReports.FirstOrDefault(x => x.ReportID == id);
                var teacherRecord = Context.Teachers.FirstOrDefault(x => x.Id == report.Teacher.Id);
                if (updateReport != null)
                {
                    updateReport.Teacher = teacherRecord;
                    updateReport.Date = report.Date;
                    Context.Update(updateReport);
                    Context.SaveChanges();
                }
            }
        }

    }
}
