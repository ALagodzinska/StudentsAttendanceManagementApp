using AttendanceApp.BLL.Context;
using AttendanceApp.Entity;
using AttendanceApp.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AttendanceApp.UI.Controllers
{
    public class ReportController : Controller
    {
        AttendanceAppOperations appOperator = new AttendanceAppOperations();
        public IActionResult Index()
        {
            var reports = BLL.DBOperations.GetAttendanceReport();
            var reportsModel = new List<AttendanceReportModel>();
            foreach (var item in reports)
            {
                var report = new AttendanceReportModel()
                {
                    ReportID = item.ReportID,
                    Teachers = item.Teacher,
                    Date = item.Date
                };
                reportsModel.Add(report);
            }            
            return View(reportsModel);
        }        

        [HttpGet]
        public IActionResult Create()
        {
            PassTeachersToView();
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] AttendanceReportModel report)
        {
            if (!ModelState.IsValid)
            {
                PassTeachersToView();
                return View(report);
            }
            var newTeacherReport = new AttendanceReport()
            {
                Teacher = report.Teachers,
                Date = report.Date
            };
            DBOperations.CreateAttendanceReport(newTeacherReport);
            
            return RedirectToAction("Index");
        }
        
        
        [HttpGet]
        public IActionResult Update([FromRoute] int? id)
        {
            var reportToEdit = appOperator.GetAttendanceReportById((int)id);
            var reportModel = new AttendanceReportModel()
            {
                ReportID = reportToEdit.ReportID,
                Teachers = reportToEdit.Teacher,
                Date = reportToEdit.Date
            };
            PassTeachersToView();
            return View(reportModel);
        }

        [HttpPost]
        public IActionResult Update([FromForm] AttendanceReportModel report, [FromRoute] int? id)
        {
            if (!ModelState.IsValid)
            {
                PassTeachersToView();
                return View(report);
            }
            var updatedReport = new AttendanceReport()
            {
                Teacher = report.Teachers,
                Date = report.Date
            };
            DBOperations.UpdateAttendanceReport(updatedReport, (int)id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int? id)
        {
            var reportToEdit = appOperator.GetAttendanceReportById((int)id);
            var reportModel = new AttendanceReportModel()
            {
                ReportID = reportToEdit.ReportID,
                Teachers = reportToEdit.Teacher,
                Date = reportToEdit.Date
            };
            PassTeachersToView();
            return View(reportModel);
        }

        [HttpPost]
        public IActionResult Delete([FromForm] AttendanceReportModel report, [FromRoute] int? id)
        {
            DBOperations.DeleteAttendanceReport((int)id);

            return RedirectToAction("Index");
        }

        public void PassTeachersToView()
        {
            var teacherModelList = new List<TeacherModel>();
            var teacherList = BLL.DBOperations.GetTeachers();
            foreach (var item in teacherList)
            {
                var teacher = new TeacherModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Course = (Subject)item.Course,
                    Email = item.Email
                };
                teacherModelList.Add(teacher);
            }
            ViewData["Teachers"] = new SelectList(teacherModelList, "Id", "Title");
        }

    }
}
    