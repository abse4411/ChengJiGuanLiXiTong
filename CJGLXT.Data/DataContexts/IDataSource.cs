using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CJGLXT.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CJGLXT.Data.DataContexts
{
    public interface IDataSource:IDisposable
    {
        DbSet<Student> Students { get; }
        DbSet<Teacher> Teachers { get; }
        DbSet<CourseRecord> CourseRecords { get; }
        DbSet<Course> Courses { get; }
        DbSet<TeacherEvaluation> TeacherEvaluations { get; }
        DbSet<StudentEvaluation> StudentEvaluations { get; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
