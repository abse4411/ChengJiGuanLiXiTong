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
        public async Task<Teacher> GetTeacherAsync(string id)
        {
            return await _dataSource.Teachers.Where(s => s.TeacherId.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IList<Teacher>> GetTeachersAsync()
        {
            return await _dataSource.Teachers.AsNoTracking().ToListAsync();
        }

        public async Task<int> AddOrUpdateTeacherAsync(Teacher teacher)
        {
            if (string.IsNullOrWhiteSpace(teacher.TeacherId))
                await _dataSource.Teachers.AddAsync(teacher);
            else
                _dataSource.Teachers.Update(teacher);
            return await _dataSource.SaveChangesAsync();
        }

        public async Task<int> DeleteTeacherAsync(Teacher teacher)
        {
            _dataSource.Teachers.Remove(teacher);
            return await _dataSource.SaveChangesAsync();
        }
    }
}
