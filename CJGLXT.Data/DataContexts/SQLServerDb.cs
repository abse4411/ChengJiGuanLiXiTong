using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.Data.Common;
using CJGLXT.Data.Data;
using CJGLXT.Data.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CJGLXT.Data.DataContexts
{
    public class SqlServerDb: DbContext, IDataSource
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=CJGLXTContext;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!String.IsNullOrWhiteSpace(SqlServeStrings.DefaultConnectionString))
                optionsBuilder.UseSqlServer(SqlServeStrings.DefaultConnectionString);
            else
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseRecordConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEvaluationConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEvaluationConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherEvaluationConfiguration());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseRecord> CourseRecords { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TeacherEvaluation> TeacherEvaluations { get; set; }
        public DbSet<StudentEvaluation> StudentEvaluations { get; set; }
    }
}
