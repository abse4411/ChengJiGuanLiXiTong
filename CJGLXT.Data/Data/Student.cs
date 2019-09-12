using System;
using System.Collections.Generic;
using System.Text;

namespace CJGLXT.Data.Data
{
    public class Student:Person
    {
        public string StudentId { get; set; }

        public List<CourseRecord> CourseRecords { get; set; }

        public List<TeacherEvaluation> TeacherEvaluations { get; set; }
    }
}
