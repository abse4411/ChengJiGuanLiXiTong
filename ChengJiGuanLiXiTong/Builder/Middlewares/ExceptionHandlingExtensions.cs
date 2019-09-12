using System;
using ChengJiGuanLiXiTong.Application;

namespace ChengJiGuanLiXiTong.Builder.Middlewares
{
    public static class ExceptionHandlingExtensions
    {
        public static IAppBuilder UseMyExceptionHandler(this IAppBuilder builder)
        {
            return builder.Use((context, next) =>
            {
                try
                {
                    next.Invoke();
                }
                catch (Exception e)
                {
                    context.Output = "程序发生异常！";
                    context.StatusCode = RequestConstants.Error;
                    Console.WriteLine($"异常:{e.Message}");
                    Console.WriteLine($"堆栈信息:{e.StackTrace}");
                }
            });
        }
    }
}
