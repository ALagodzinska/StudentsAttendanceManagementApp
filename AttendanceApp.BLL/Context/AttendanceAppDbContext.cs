using AttendanceApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApp.BLL.Context
{
    public class AttendanceAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<AttendanceReport> AttendanceReports {get; set;}
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentAttendancy> StudentAttendancy { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-3UCCBUV\SQLEXPRESS01; Database=AttendanceAppDB; Trusted_Connection=True;");
    }
}
