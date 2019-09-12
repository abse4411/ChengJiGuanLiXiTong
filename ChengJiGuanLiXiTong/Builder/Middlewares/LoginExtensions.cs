using System;
using System.Text;
using ChengJiGuanLiXiTong.Application;
using ChengJiGuanLiXiTong.Helpers;

namespace ChengJiGuanLiXiTong.Builder.Middlewares
{
    public static class LoginExtensions
    {
        public static IAppBuilder UseLogin(this IAppBuilder builder)
        {
            return builder.Use((context, next) =>
            {
                PrintMessage();
                int result;
                while (!InputHelper.ReadInt32("请输入功能序号：", "请输入正确的序号！\n\n",
                    (value) => (value == 1 || value == 2), out result))
                {
                }

                if (result == 2)
                {
                    context.StatusCode = RequestConstants.Exit;
                    context.Output = "用户退出程序";
                    return;
                }
                Login(context, next);
            });
        }

        private static void PrintMessage()
        {
            Console.WriteLine("欢迎来到学生管理系统");
            Console.WriteLine("你要做什么？");
            Console.WriteLine("1.登录\t2.退出");
        }

        private static void Login(RequestContext context, Action next)
        {
            var userType = ReadUserType();
            var userName = ReadUserName();
            var password = ReadPassword();
            var dictionary = context.Input;

            if (!dictionary.ContainsKey(RequestConstants.UserType))
                dictionary.Add(RequestConstants.UserType, userType);
            else
                dictionary[RequestConstants.UserType] = userType;
            if (!dictionary.ContainsKey(RequestConstants.UserName))
                dictionary.Add(RequestConstants.UserName, userName);
            else
                dictionary[RequestConstants.UserName] = userName;
            if (!dictionary.ContainsKey(RequestConstants.Password))
                dictionary.Add(RequestConstants.Password, password);
            else
                dictionary[RequestConstants.Password] = password;

            next.Invoke();
        }

        private static string ReadUserType()
        {
            int result;
            while (!InputHelper.ReadInt32("选择登录用户身份（输入序号）：\n1.学生\t2.教师\n", "请输入正确的序号!\n\n",
                (value) => value==1 || value == 2, out result))
            {
            }

            if (result == 1)
                return RequestConstants.Student;
            else
                return RequestConstants.Teacher;
        }

        private static String ReadUserName()
        {
            string result;
            while (!InputHelper.ReadString("请输入用户名：", "用户名不能为空!\n\n",
                (userName) => !string.IsNullOrWhiteSpace(userName), out result))
            {
            }

            return result;
        }

        private static String ReadPassword()
        {
            StringBuilder password = new StringBuilder(100);

            Console.Write("请输入密码:");

            while (true)
            {
                ConsoleKeyInfo ck = Console.ReadKey(true);
                if (ck.Key != ConsoleKey.Enter)
                {
                    if (ck.Key != ConsoleKey.Backspace)
                    {
                        password.Append(ck.KeyChar);
                    }
                    else
                    {
                        if (password.Length > 0)
                            password.Remove(password.Length - 1, 1);
                    }
                }
                else
                {
                    Console.WriteLine();
                    break;
                }
            }

            return password.ToString();
        }
    }
}
