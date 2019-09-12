using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.Data.Data;

namespace CJGLXT.Data.DataServices
{
    public interface IDataService: IDisposable
    {
        Task<Student> GetStudentAsync(string id);
        Task<IList<Student>> GetStudentsAsync();
        Task<int> AddOrUpdateStudentAsync(Student student);
        Task<int> DeleteStudentAsync(Student student);
    }
}
