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
        AttendanceAppOperations appOperator = new AttendanceAppOperations();
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
                        Id = item.Id,
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
            PassStudentsToView((int) id);
            var student = new StudentAttendancyModel()
            {
                ReportID = (int)id,
            };
            return View(student);
        }

        [HttpPost]
        public IActionResult Create([FromForm] StudentAttendancyModel studentAttendance, [FromRoute] int? id)
        {            
            if (!ModelState.IsValid)
            {
                PassStudentsToView((int)id);
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

        [HttpGet]
        public IActionResult Update([FromRoute] int? id)
        {
            var attendancyToEdit = DBOperations.GetStudentAttendancyById((int)id);
            var attendancyModel = new StudentAttendancyModel()
            {
                Id = attendancyToEdit.Id,
                ReportID = attendancyToEdit.Report.ReportID,
                Student = attendancyToEdit.Student,
                IsPresent = attendancyToEdit.IsPresent
            };
            return View(attendancyModel);
        }

        [HttpPost]
        public IActionResult Update([FromForm] StudentAttendancyModel report, [FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                return View(report);
            }
            var reportById = appOperator.GetAttendanceReportById(report.ReportID);
            var updatedReport = new StudentAttendancy()
            {
                Id = report.Id,
                Student = report.Student,
                Report = reportById,
                IsPresent = report.IsPresent
            };
            DBOperations.UpdateStudentAttendancy(updatedReport);

            return RedirectToAction("Index", new { id = report.ReportID});
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int? id)
        {
            var reportToDelete = DBOperations.GetStudentAttendancyById((int)id);
            var attendancyModel = new StudentAttendancyModel()
            {
                Id = reportToDelete.Id,
                Student = reportToDelete.Student,
                ReportID = reportToDelete.Report.ReportID,
                IsPresent = reportToDelete.IsPresent
            };
            return View(attendancyModel);
        }

        [HttpPost]
        public IActionResult Delete([FromForm] StudentAttendancyModel attendancyReport, [FromRoute] int? id)
        {
            DBOperations.DeleteStudentAttendancy((int)id);

            return RedirectToAction("Index", new { id = attendancyReport.ReportID });
        }
        public IActionResult AddMissing([FromRoute] int? id)
        {
            appOperator.AddMissingStudents((int)id);
            return RedirectToAction("Index", new { id = id });
        }
        public IActionResult AllPresent([FromRoute] int? id)
        {
            appOperator.MarkAllStudentsPresent((int)id);
            return RedirectToAction("Index", new { id = id });
        }
        public IActionResult AllAbsent([FromRoute] int? id)
        {
            appOperator.MarkAllStudentsAbsent((int)id);
            return RedirectToAction("Index", new { id = id });
        }
        public IActionResult ChangeIsPresent([FromRoute] int? id)
        {
            var studentAttendancy = DBOperations.GetStudentAttendancyById((int)id);
            appOperator.ChangeStudentPresent((int)id);
            return RedirectToAction("Index", new { id = studentAttendancy.Report.ReportID});
        }

        public void PassStudentsToView(int reportId)
        {
            var studentModelList = new List<StudentModel>();
            var studentList = appOperator.GetAvailableStudentList(reportId);
            foreach (var item in studentList)
            {
                var student = new StudentModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Age = item.Age,
                    StudentGroupID = (StudentGroup)item.StudentGroupID,
                    Email = item.Email
                };
                studentModelList.Add(student);
            }
            ViewData["Students"] = new SelectList(studentModelList, "Id", "Title");
        }
    }
}
