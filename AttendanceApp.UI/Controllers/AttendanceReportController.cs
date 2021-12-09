using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApp.UI.Controllers
{
    public class AttendanceReportController : Controller
    {
        public IActionResult Index()
        {
            var studentList = BLL.DBOperations.GetStudents();
            return View(studentList);
        }
    }
}
