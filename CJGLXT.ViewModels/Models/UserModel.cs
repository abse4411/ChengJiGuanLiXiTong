using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.Models
{
    public enum UserType
    {
        Student, Teacher
    }

    public class UserModel: ObservableObject
    {
        public UserType UserType { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        public override void Merge(ObservableObject source)
        {
            if (source is UserModel model)
            {
                Merge(model);
            }
        }

        public void Merge(UserModel source)
        {
            if (source != null)
            {
                UserType = source.UserType;
                UserName = source.UserName;
                UserId = source.UserId;
                Password = source.Password;
            }
        }
    }
}
