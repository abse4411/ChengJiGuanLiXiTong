using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CJGLXT.Data.Data.EntityConfigurations
{
    class CourseRecordConfiguration: IEntityTypeConfiguration<CourseRecord>
    {
        public void Configure(EntityTypeBuilder<CourseRecord> builder)
        {
            builder.HasKey(x => new {x.StudentId, x.CourseId});

            builder.HasOne(x => x.Student)
                .WithMany(s => s.CourseRecords)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Course)
                .WithMany(s => s.CourseRecords)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
