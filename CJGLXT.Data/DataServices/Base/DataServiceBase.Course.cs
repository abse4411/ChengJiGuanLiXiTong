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
        public async Task<Course> GetCourseAsync(int id)
        {
            return await _dataSource.Courses.Where(s => s.CourseId==id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IList<Course>> GetCoursesAsync()
        {
            return await _dataSource.Courses.AsNoTracking().ToListAsync();
        }

        public async Task<int> AddOrUpdateCourseAsync(Course course)
        {
            if (course.CourseId<=0)
                await _dataSource.Courses.AddAsync(course);
            else
                _dataSource.Courses.Update(course);
            return await _dataSource.SaveChangesAsync();
        }

        public async Task<int> DeleteCourseAsync(Course course)
        {
            _dataSource.Courses.Remove(course);
            return await _dataSource.SaveChangesAsync();
        }
    }
}
