using AttendanceApp.BLL;
using AttendanceApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApp.UI.Controllers
{
    public class StudentController : Controller
    {
        AttendanceAppOperations appOperator = new AttendanceAppOperations();
        public IActionResult Index()
        {
            var studentsList = BLL.DBOperations.GetStudents();
            var studentModel = new List<StudentModel>();
            foreach (var item in studentsList)
            {
                var student = new StudentModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Age = item.Age,
                    Email = item.Email,
                    StudentGroupID = (StudentGroup)item.StudentGroupID
                };
                studentModel.Add(student);
            }
            return View(studentModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            var newStudent = new Student()
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
                Email = student.Email,
                StudentGroupID = (Entity.StudentGroup)student.StudentGroupID
            };
            DBOperations.CreateStudent(newStudent);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int? id)
        {
            var studentToEdit = appOperator.GetStudentById((int)id);
            var studentModel = new StudentModel()
            {
                Id = studentToEdit.Id,
                Name = studentToEdit.Name,
                Surname = studentToEdit.Surname,
                Age = studentToEdit.Age,
                Email = studentToEdit.Email,
                StudentGroupID = (StudentGroup)studentToEdit.StudentGroupID
            };
            return View(studentModel);
        }

        [HttpPost]
        public IActionResult Update([FromForm] StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            var updatedStudent = new Student()
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
                Email = student.Email,
                StudentGroupID = (Entity.StudentGroup)student.StudentGroupID
            };
            DBOperations.UpdateStudent(updatedStudent);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int? id)
        {
            var studentToDelete = appOperator.GetStudentById((int)id);
            var studentModel = new StudentModel()
            {
                Id = studentToDelete.Id,
                Name = studentToDelete.Name,
                Surname = studentToDelete.Surname,
                Age = studentToDelete.Age,
                Email = studentToDelete.Email,
                StudentGroupID = (StudentGroup)studentToDelete.StudentGroupID
            };
            return View(studentModel);
        }

        [HttpPost]
        public IActionResult Delete([FromForm] StudentModel student)
        {
            DBOperations.DeleteStudent(student.Id);

            return RedirectToAction("Index");
        }
    }
}
