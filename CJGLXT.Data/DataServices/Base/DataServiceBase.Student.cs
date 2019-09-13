using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace CJGLXT.Data.DataServices.Base
{
    partial class DataServiceBase
    {
        public async Task<Student> GetStudentAsync(string id)
        {
            return await _dataSource.Students.Where(s => s.StudentId.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IList<Student>> GetStudentsAsync()
        {
            return await _dataSource.Students.AsNoTracking().ToListAsync();
        }

        public async Task<int> AddOrUpdateStudentAsync(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.StudentId))
                await _dataSource.Students.AddAsync(student);
            else
                _dataSource.Students.Update(student);
            return await _dataSource.SaveChangesAsync();
        }

        public async Task<int> DeleteStudentAsync(Student student)
        {
            _dataSource.Students.Remove(student);
            return await _dataSource.SaveChangesAsync();
        }
    }
}
