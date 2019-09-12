using System;

namespace ChengJiGuanLiXiTong.Application
{
    public static class RequestConstants
    {
        public const Int32 None = 0;
        public const Int32 SuccessfulAuthentication = 1;
        public const Int32 AuthenticationFailure = 2;
        public const Int32 Error = 3;
        public const Int32 Exit = 4;

        public const String UserName = "UserName";
        public const String Password = "Password";
        public const String Student = "Student";
        public const String Teacher = "Teacher";
        public const String UserType = "UserType";

    }
}
