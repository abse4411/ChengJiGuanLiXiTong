using System;
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
    class StudentService : IStudentService
    {
        private readonly IDataServiceFactory _dataServiceFactory;

        public StudentService(IDataServiceFactory dataServiceFactory)
        {
            _dataServiceFactory = dataServiceFactory;
        }
        public async Task<StudentModel> GetStudentAsync(string id)
        {
            Student student;
            using (var dataService = _dataServiceFactory.CreateDataService())
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
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var students = await dataService.GetStudentsAsync();
                foreach (var student in students)
                {
                    result.Add(CreateStudentModel(student));
                }
            }
            return result;
        }

        public async Task<int> AddOrUpdateStudentAsync(StudentModel model)
        {
            string id = model.StudentId;
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var student = !string.IsNullOrWhiteSpace(id) ? await dataService.GetStudentAsync(id) : new Student();
                if (student != null)
                {
                    UpdateStudentFromModel(student, model);
                    var result = await dataService.AddOrUpdateStudentAsync(student);
                    model.Merge(await GetStudentAsync(student.StudentId));
                    return result;
                }
                return 0;
            }
        }

        private static void UpdateStudentFromModel(Student target, StudentModel source)
        {
            target.Name = source.Name;
            target.Password = source.Password;
            target.Sex = source.Sex;
            target.Age = source.Age;
        }

        public async Task<int> DeleteStudentAsync(StudentModel model)
        {
            var student = new Student { StudentId = model.StudentId };
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                return await dataService.DeleteStudentAsync(student);
            }
        }
    }
}
