using System;
using System.Collections.Generic;
using ChengJiGuanLiXiTong.Application;

namespace ChengJiGuanLiXiTong.Builder.Middlewares
{
    public static class AuthenticationExtensions
    {
        public static IAppBuilder UseAuthentication(this IAppBuilder builder)
        {
            return builder.Use((context, next) =>
            {

                var dictionary = context.Input;
                if (dictionary.TryGetValue(RequestConstants.UserName, out var userName) &&
                    dictionary.TryGetValue(RequestConstants.Password, out var password) &&
                    dictionary.TryGetValue(RequestConstants.UserType, out var userType))
                {
                    if (!String.IsNullOrWhiteSpace(password) && 
                        !String.IsNullOrWhiteSpace(userName) && 
                        !String.IsNullOrWhiteSpace(userType) &&
                        String.Equals(password, "123"))
                    {
                        context.StatusCode = RequestConstants.SuccessfulAuthentication;
                        Console.WriteLine($"身份验证通过，你好{userName}\n当前时间：{DateTime.Now}\n\n");
                        next.Invoke();
                        context.StatusCode = RequestConstants.None;
                        Console.WriteLine("用户退出登录\n\n");
                        return;
                    }
                }
                context.StatusCode = RequestConstants.AuthenticationFailure;
                context.Output = "用户身份验证失败，无法验证用户信息！\n\n";
                Console.WriteLine(context.Output);
            });
        }
    }
}
