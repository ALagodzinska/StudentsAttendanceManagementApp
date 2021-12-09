using AttendanceApp.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApp.UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessLogin(User user)
        {
            AttendanceAppOperations attendanceOperator = new AttendanceAppOperations();
            User databaseUser = attendanceOperator.GetUser(user);
            if (databaseUser != null)
            {
                return View("LoginSuccess", databaseUser);
            }
            else
            {
                return View("LoginFail", user);
            }
        }
    }
}
