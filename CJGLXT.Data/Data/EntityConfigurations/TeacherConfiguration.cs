using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CJGLXT.Data.Data.EntityConfigurations
{
    class TeacherConfiguration: IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Sex).IsRequired();
        }
    }
}
