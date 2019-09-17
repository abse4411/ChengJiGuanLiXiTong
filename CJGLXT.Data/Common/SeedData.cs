using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.Data.Data;

namespace CJGLXT.Data.Common
{
    public class SeedData
    {
        public static IList<Student> GetStudents()
        {
            var result=new List<Student>();
            result.Add(new Student
            {
                StudentId = "221701339",
                Name = "张三",
                Age = 19,
                Sex = "男"
            });
            result.Add(new Student
            {
                StudentId = "221701340",
                Name = "李四",
                Age = 21,
                Sex = "男"
            });
            result.Add(new Student
            {
                StudentId = "221701341",
                Name = "王明",
                Age = 22,
                Sex = "男"
            });
            result.Add(new Student
            {
                StudentId = "221701342",
                Name = "王明",
                Age = 22,
                Sex = "男"
            });
            result.Add(new Student
            {
                StudentId = "221701343",
                Name = "王明",
                Age = 21,
                Sex = "男"
            });
            result.Add(new Student
            {
                StudentId = "221701344",
                Name = "李红",
                Age = 20,
                Sex = "女"
            });
            return result;
        }

    }
}
