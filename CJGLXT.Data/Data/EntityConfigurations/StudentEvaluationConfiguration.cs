using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CJGLXT.Data.Data.EntityConfigurations
{
    class StudentEvaluationConfiguration: IEntityTypeConfiguration<StudentEvaluation>
    {
        public void Configure(EntityTypeBuilder<StudentEvaluation> builder)
        {
            builder.HasKey(x => new { x.StudentId, x.TeacherId });

            builder.Property(x => x.Content).IsRequired();
        }
    }
}
