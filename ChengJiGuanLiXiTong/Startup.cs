using System;
using System.Collections.Generic;
using System.Text;
using ChengJiGuanLiXiTong.Builder;
using ChengJiGuanLiXiTong.Builder.Middlewares;

namespace ChengJiGuanLiXiTong
{
    public class Startup
    {
        public void Configure(IAppBuilder builder)
        {
            builder.UseMyExceptionHandler();
            builder.UseLogin();
            builder.UseAuthentication();
        }
    }
}
