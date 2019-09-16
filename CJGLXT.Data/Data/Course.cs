using System;
using System.Collections.Generic;
using System.Text;

namespace CJGLXT.Data.Data
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<CourseRecord> CourseRecords { get; set; }
    }
}
