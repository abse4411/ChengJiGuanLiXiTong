using System;
using System.Collections.Generic;
using System.Text;

namespace CJGLXT.Data.Data
{
    public class Teacher:Person
    {
        public string TeacherId { get; set; }

        public IList<StudentEvaluation> StudentEvaluations { get; set; }
    }
}
