using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CJGLXT.Data.Data.EntityConfigurations
{
    class TeacherEvaluationConfiguration:IEntityTypeConfiguration<TeacherEvaluation>
    {
        public void Configure(EntityTypeBuilder<TeacherEvaluation> builder)
        {
            builder.HasKey(x => new { x.StudentId, x.TeacherId });

            builder.Property(x => x.Content).IsRequired();
        }
    }
}
