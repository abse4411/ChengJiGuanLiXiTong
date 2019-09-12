using System;
using System.Collections.Generic;
using System.Text;

namespace CJGLXT.Data.Data
{
    public class Evaluation
    {
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }

        public string Content { get; set; }
    }
}
