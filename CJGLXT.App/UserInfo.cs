using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJGLXT.App
{
    public enum UserType
    {
        Student,Teacher
    }
    public class UserInfo
    {
        public UserType UserType { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
