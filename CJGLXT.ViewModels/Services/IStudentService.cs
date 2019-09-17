using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;

namespace CJGLXT.ViewModels.Services
{
    public interface IStudentService
    {
        Task<StudentModel> GetStudentAsync(string id);
        Task<IList<StudentModel>> GetStudentsAsync();
        Task<int> AddStudentAsync(StudentModel model);
        Task<int> UpdateStudentAsync(StudentModel model);

        Task<int> DeleteStudentAsync(StudentModel model);

    }
}
