using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CJGLXT.Data.Data.EntityConfigurations
{
    class CourseConfiguration: IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CourseId).ValueGeneratedNever();
        }
    }
}
