using System;
using System.Collections.Generic;
using System.Text;

namespace CJGLXT.Data.Data
{
    public class Student:Person
    {
        public string StudentId { get; set; }

        public IList<CourseRecord> CourseRecords { get; set; }

        public IList<TeacherEvaluation> TeacherEvaluations { get; set; }
    }
}
