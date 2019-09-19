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
                StudentId = "std",
                Name = "张三",
                Age = 19,
                Sex = "男",
                Password = "std"
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
                Name = "刘旭",
                Age = 22,
                Sex = "男"
            });
            result.Add(new Student
            {
                StudentId = "221701342",
                Name = "徐东",
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

        public static IList<Teacher> GetTeachers()
        {
            var result = new List<Teacher>();
            result.Add(new Teacher
            {
                TeacherId = "admin",
                Name = "陈敏",
                Age = 35,
                Sex = "女",
                Password = "admin"
            });
            result.Add(new Teacher
            {
                TeacherId = "ZhangFan",
                Name = "张帆",
                Age = 35,
                Sex = "男"
            });
            return result;
        }

        public static IList<Course> GetCourses()
        {
            var result = new List<Course>();
            result.Add(new Course
            {
                CourseId = 1,
                Name = "C#程序设计",
                Description = "暂无",

            });
            result.Add(new Course
            {
                CourseId = 2,
                Name = "面向对象程序设计分析",
                Description = "暂无"
            });
            result.Add(new Course
            {
                CourseId = 3,
                Name = "Java程序设计",
                Description = "暂无",

            });
            result.Add(new Course
            {
                CourseId = 4,
                Name = "数据库原理",
                Description = "暂无",

            });
            result.Add(new Course
            {
                CourseId = 5,
                Name = "数值计算",
                Description = "暂无",

            });
            return result;
        }

        public static IList<CourseRecord> GetCourseRecords()
        {
            var result = new List<CourseRecord>();
            result.Add(new CourseRecord
            {
                StudentId = "std",
                CourseId = 1,
                Score = 100
            });
            result.Add(new CourseRecord
            {
                StudentId = "std",
                CourseId = 2,
                Score = 99
            });
            result.Add(new CourseRecord
            {
                StudentId = "std",
                CourseId = 3,
                Score = 89
            });
            result.Add(new CourseRecord
            {
                StudentId = "std",
                CourseId = 4,
                Score = 88
            });
            result.Add(new CourseRecord
            {
                StudentId = "std",
                CourseId = 5,
                Score = 85
            });

            result.Add(new CourseRecord
            {
                StudentId = "221701340",
                CourseId = 1,
                Score = 79
            });
            result.Add(new CourseRecord
            {
                StudentId = "221701340",
                CourseId = 2,
                Score = 85
            });
            result.Add(new CourseRecord
            {
                StudentId = "221701340",
                CourseId = 3,
            });
            result.Add(new CourseRecord
            {
                StudentId = "221701340",
                CourseId = 4,
            });
            result.Add(new CourseRecord
            {
                StudentId = "221701340",
                CourseId = 5,
                Score = 85
            });

            result.Add(new CourseRecord
            {
                StudentId = "221701341",
                CourseId = 1,
                Score = 77
            });
            result.Add(new CourseRecord
            {
                StudentId = "221701342",
                CourseId = 2,
                Score = 78
            });
            result.Add(new CourseRecord
            {
                StudentId = "221701343",
                CourseId = 3,
            });
            result.Add(new CourseRecord
            {
                StudentId = "221701344",
                CourseId = 4,
                Score = 60
            });
            result.Add(new CourseRecord
            {
                StudentId = "221701341",
                CourseId = 5,
                Score = 89
            });

            return result;
        }

        public static IList<StudentEvaluation> GetStudentEvaluations()
        {
            var result = new List<StudentEvaluation>();
            result.Add(new StudentEvaluation
            {
                TeacherId = "admin",
                StudentId = "std",
                Content = "测试评价",
            });
            result.Add(new StudentEvaluation
            {
                TeacherId = "admin",
                StudentId = "221701341",
                Content = "测试评价",
            });
            result.Add(new StudentEvaluation
            {
                TeacherId = "admin",
                StudentId = "221701342",
                Content = "测试评价",
            });
            result.Add(new StudentEvaluation
            {
                TeacherId = "admin",
                StudentId = "221701343",
                Content = "测试评价",
            });


            result.Add(new StudentEvaluation
            {
                TeacherId = "ZhangFan",
                StudentId = "std",
                Content = "测试评价",
            });
            result.Add(new StudentEvaluation
            {
                TeacherId = "ZhangFan",
                StudentId = "221701342",
                Content = "测试评价",
            });
            result.Add(new StudentEvaluation
            {
                TeacherId = "ZhangFan",
                StudentId = "221701343",
                Content = "测试评价",
            });
            result.Add(new StudentEvaluation
            {
                TeacherId = "ZhangFan",
                StudentId = "221701344",
                Content = "测试评价",
            });
            return result;
        }

        public static IList<TeacherEvaluation> GetTeacherEvaluations()
        {
            var result = new List<TeacherEvaluation>();
            result.Add(new TeacherEvaluation
            {
                TeacherId = "admin",
                StudentId = "std",
                Content = "测试评价",
            });
            result.Add(new TeacherEvaluation
            {
                TeacherId = "admin",
                StudentId = "221701341",
                Content = "测试评价",
            });
            result.Add(new TeacherEvaluation
            {
                TeacherId = "admin",
                StudentId = "221701342",
                Content = "测试评价",
            });
            result.Add(new TeacherEvaluation
            {
                TeacherId = "admin",
                StudentId = "221701343",
                Content = "测试评价",
            });


            result.Add(new TeacherEvaluation
            {
                TeacherId = "ZhangFan",
                StudentId = "std",
                Content = "测试评价",
            });
            result.Add(new TeacherEvaluation
            {
                TeacherId = "ZhangFan",
                StudentId = "221701342",
                Content = "测试评价",
            });
            result.Add(new TeacherEvaluation
            {
                TeacherId = "ZhangFan",
                StudentId = "221701343",
                Content = "测试评价",
            });
            result.Add(new TeacherEvaluation
            {
                TeacherId = "ZhangFan",
                StudentId = "221701344",
                Content = "测试评价",
            });
            return result;
        }
    }
}
