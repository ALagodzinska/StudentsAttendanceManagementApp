using AttendanceApp.BLL;
using AttendanceApp.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApp.UI.Controllers
{
    public class LoginController : Controller
    {
        AttendanceAppOperations attendanceOperator = new AttendanceAppOperations();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessLogin(UserModel user)
        {
            var enteredUser = new User()
            {
                UserName = user.UserName,
                Password = user.Password
            };
            User databaseUser = attendanceOperator.GetUserByCreds(enteredUser);
            if (databaseUser != null)
            {
                return View("LoginSuccess", user);
            }
            else
            {
                return View("LoginFail", user);
            }
        }
    }
}
