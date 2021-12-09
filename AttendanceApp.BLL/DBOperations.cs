using AttendanceApp.BLL.Context;
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
    }
}
