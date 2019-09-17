using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CJGLXT.Data.Data.EntityConfigurations
{
    class StudentConfiguration: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Sex).IsRequired();
            //builder.Property(x => x.StudentId).ValueGeneratedNever();
        }
    }
}
