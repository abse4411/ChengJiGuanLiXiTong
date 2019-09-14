using System;
using System.Linq;
using System.Threading.Tasks;
using ChengJiGuanLiXiTong.Application;
using ChengJiGuanLiXiTong.Builder;
using ChengJiGuanLiXiTong.Builder.Middlewares;
using CJGLXT.Data.DataContexts;
using CJGLXT.Data.DataServices;
using Microsoft.EntityFrameworkCore;

namespace ChengJiGuanLiXiTong
{
    class Program
    {
        static void Main(String[] args)
        {
            try
            {
                int? x=null;
                Console.WriteLine(x);
                //using (var db = new SqlServerDb())
                //{

                //    var record = db.CourseRecords.Find("221701340", 6);
                //    if (record != null)
                //    {
                //        Console.WriteLine(record.Score);
                //    }
                //    else
                //    {
                //        Console.WriteLine("Not Found!");
                //    }
                //}

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine("+++++++++++++++++");
            Console.ReadLine();
        }

        public static void RunApp()
        {
            RequestResult result;
            var app = CreateAppBuilder().Build();
            do
            {
                result = app.Run();
            } while (result.StatusCode != RequestConstants.Exit && result.StatusCode != RequestConstants.Error);
        }

        public static IAppBuilder CreateAppBuilder()
        {
            return App.CreateDefaultBuilder().UseStartup(new Startup());
        }
    }
}
