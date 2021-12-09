using System;
using System.Linq;

namespace AttendanceApp.BLL
{
    public class AttendanceAppOperations : IAttendanceAppOperations
    {
        public User GetUser(User user)
        {
            var userList = DBOperations.GetUsers();
            return userList.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
        }
    }
}
