using System;
using System.Linq;
using System.Threading.Tasks;
using ChengJiGuanLiXiTong.Application;
using ChengJiGuanLiXiTong.Builder;
using ChengJiGuanLiXiTong.Builder.Middlewares;
using CJGLXT.Data.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace ChengJiGuanLiXiTong
{
    class Program
    {
        static void Main(String[] args)
        {
            try
            {
                using (var db = new SqlServerDb())
                {
                    var students = db.Students.Include(x => x.CourseRecords)
                        .ThenInclude(cd=>cd.Course)
                        .ToList();
                    var courses = db.Courses.Include(x => x.CourseRecords)
                        .ThenInclude(cd=>cd.Student)
                        .ToList();
                    Console.WriteLine("Students_______________________________________________________");
                    foreach (var s in students)
                    {
                        Console.WriteLine("StudentId\t\tStudentName\tSex\t\tAge");
                        Console.WriteLine($"{s.StudentId}\t\t{s.Name}\t\t{s.Sex}\t\t{s.Age}\n\n");
                        Console.WriteLine("CourseId\tCourseName\t\tScore");
                        foreach (var c in s.CourseRecords)
                        {
                            Console.WriteLine($"{c.CourseId}\t\t{c.Course.Name}\t\t{c.Score}");
                        }
                        Console.WriteLine("====================================================");
                    }

                    Console.WriteLine("Courses_______________________________________________________");
                    foreach (var c in courses)
                    {
                        Console.WriteLine("CourseId\tCourseName\t\tDescription");
                        Console.WriteLine($"{c.CourseId}\t\t{c.Name}\t\t{c.Description}\n\n");
                        Console.WriteLine("StudentId\t\tStudentName\tScore");
                        foreach (var cd in c.CourseRecords)
                        {
                            Console.WriteLine($"{cd.StudentId}\t\t{cd.Student.Name}\t\t{cd.Score}");
                        }
                        Console.WriteLine("====================================================");
                    }

                }

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
