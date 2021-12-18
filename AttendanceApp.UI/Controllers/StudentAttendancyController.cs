using AttendanceApp.BLL;
using AttendanceApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApp.UI.Controllers
{
    public class StudentAttendancyController : Controller
    {
        public IActionResult Index([FromRoute] int? id)
        {
            ViewData["ReportID"] = (int)id;

            var students = BLL.DBOperations.GetStudentAttendancy((int)id);

            var studentsModels = new List<StudentAttendancyModel>();
            if (students != null)
            {
                foreach (var item in students)
                {
                    var student = new StudentAttendancyModel()
                    {
                        ReportID = item.Report.ReportID,
                        Student = item.Student,
                        IsPresent = item.IsPresent
                    };
                    studentsModels.Add(student);
                }
            }
            return View(studentsModels);
        }
        [HttpGet]
        public IActionResult Create(int? id)
        {
            PassStudentsToView();
            var student = new StudentAttendancyModel()
            {
                ReportID = (int)id,
            };
            return View(student);
        }

        [HttpPost]
        public IActionResult Create([FromForm] StudentAttendancyModel studentAttendance, [FromRoute] int? id)
        {
            PassStudentsToView();
            if (!ModelState.IsValid)
            {
                return View(studentAttendance);
            }
            var newStudentAttendance = new StudentAttendancy()
            {
                Student = studentAttendance.Student,
                IsPresent = studentAttendance.IsPresent
            };
            DBOperations.CreateStudentAttendancy(newStudentAttendance, (int)id);

            return RedirectToAction("Index", new { id = (int)id });
        }
        public void PassStudentsToView()
        {
            var studentModelList = new List<StudentModel>();
            var studentList = BLL.DBOperations.GetStudents();
            foreach (var item in studentList)
            {
                var student = new StudentModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Age = item.Age,
                    StudentGroupID = item.StudentGroupID,
                    Email = item.Email,
                    IsPresent = item.IsPresent
                };
                studentModelList.Add(student);
            }
            ViewData["Students"] = new SelectList(studentModelList, "Id", "Title");
        }
    }
}
