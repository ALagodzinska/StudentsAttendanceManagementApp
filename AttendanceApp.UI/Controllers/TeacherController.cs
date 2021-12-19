using AttendanceApp.BLL;
using AttendanceApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApp.UI.Controllers
{
    public class TeacherController : Controller
    {
        AttendanceAppOperations appOperator = new AttendanceAppOperations();
        public IActionResult Index()
        {
            var teachersList = BLL.DBOperations.GetTeachers();
            var teachersModel = new List<TeacherModel>();
            foreach (var item in teachersList)
            {
                var teacher = new TeacherModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Course = (Subject)item.Course,
                    Email = item.Email
                };
                teachersModel.Add(teacher);
            }
            return View(teachersModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] TeacherModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            var newTeacher = new Teacher()
            {
                Name = teacher.Name,
                Surname = teacher.Surname,
                Course = (Entity.Subject)teacher.Course,
                Email = teacher.Email
            };
            DBOperations.CreateTeacher(newTeacher);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int? id)
        {
            var teacherToEdit = appOperator.GetTeacherById((int)id);
            var teacherModel = new TeacherModel()
            {
                Id = teacherToEdit.Id,
                Name = teacherToEdit.Name,
                Surname = teacherToEdit.Surname,
                Course = (Subject)teacherToEdit.Course,
                Email = teacherToEdit.Email
            };
            return View(teacherModel);
        }

        [HttpPost]
        public IActionResult Update([FromForm] TeacherModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            var updatedTeacher = new Teacher()
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Surname = teacher.Surname,
                Course = (Entity.Subject)teacher.Course,
                Email = teacher.Email
            };
            DBOperations.UpdateTeacher(updatedTeacher);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int? id)
        {
            var teacherToEdit = appOperator.GetTeacherById((int)id);
            var teacherModel = new TeacherModel()
            {
                Id = teacherToEdit.Id,
                Name = teacherToEdit.Name,
                Surname = teacherToEdit.Surname,
                Course = (Subject)teacherToEdit.Course,
                Email = teacherToEdit.Email
            };
            return View(teacherModel);
        }

        [HttpPost]
        public IActionResult Delete([FromForm] TeacherModel teacher)
        {
            DBOperations.DeleteTeacher(teacher.Id);

            return RedirectToAction("Index");
        }
    }
}
