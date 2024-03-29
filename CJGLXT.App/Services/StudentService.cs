﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.App.Services.DataServiceFactory;
using CJGLXT.Data.Data;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;

namespace CJGLXT.App.Services
{
    class StudentService : DataServiceBase,IStudentService
    {
        public StudentService(IDataServiceFactory dataServiceFactory) : base(dataServiceFactory)
        {
        }
        public async Task<StudentModel> GetStudentAsync(string id)
        {
            Student student;
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                student = await dataService.GetStudentAsync(id);
            }
            if (student != null)
                return CreateStudentModel(student);
            return null;
        }

        private static StudentModel CreateStudentModel(Student student)
        {
            return new StudentModel
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Password = student.Password,
                Age = student.Age,
                Sex = student.Sex
            };
        }

        public async Task<IList<StudentModel>> GetStudentsAsync()
        {
            IList<StudentModel> result = new List<StudentModel>();
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                var students = await dataService.GetStudentsAsync();
                foreach (var student in students)
                {
                    result.Add(CreateStudentModel(student));
                }
            }
            return result;
        }

        public async Task<int> AddStudentAsync(StudentModel model)
        {
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                var student = new Student();
                UpdateStudentFromModel(student, model);
                var result = await dataService.AddStudentAsync(student);
                model.Merge(await GetStudentAsync(student.StudentId));
                return result;
            }
        }

        public async Task<int> UpdateStudentAsync(StudentModel model)
        {
            string id = model.StudentId;
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                var student = !string.IsNullOrWhiteSpace(id) ? await dataService.GetStudentAsync(id) : new Student();
                if (student != null)
                {
                    UpdateStudentFromModel(student, model);
                    var result = await dataService.UpdateStudentAsync(student);
                    model.Merge(await GetStudentAsync(student.StudentId));
                    return result;
                }
                return 0;
            }
        }

        private static void UpdateStudentFromModel(Student target, StudentModel source)
        {
            target.StudentId = source.StudentId;
            target.Name = source.Name;
            target.Password = source.Password;
            target.Sex = source.Sex;
            target.Age = source.Age;
        }

        public async Task<int> DeleteStudentAsync(StudentModel model)
        {
            var student = new Student { StudentId = model.StudentId };
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                return await dataService.DeleteStudentAsync(student);
            }
        }
    }
}
