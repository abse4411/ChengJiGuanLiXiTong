using System;
using System.Collections.Generic;
using System.Text;
using ChengJiGuanLiXiTong.Builder;

namespace ChengJiGuanLiXiTong.Application
{
    public static class App
    {
        public static IAppBuilder CreateDefaultBuilder()
        {
            return new AppBuilder();
        }
    }
}
