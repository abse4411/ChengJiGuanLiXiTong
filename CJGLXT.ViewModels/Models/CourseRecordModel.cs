using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.Data.Data;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.Models
{
    public class CourseRecordModel:ObservableObject
    {
        public string StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int? Score { get; set; }

        public bool IsNew { get; set; } = true;

        public static CourseRecordModel CreateEmpty() => new CourseRecordModel { CourseId = -1, StudentId=null, IsEmpty = true };

        public override void Merge(ObservableObject source)
        {
            if (source is CourseRecordModel model)
            {
                Merge(model);
            }
        }

        public void Merge(CourseRecordModel source)
        {
            if (source != null)
            {
                Course = source.Course;
                CourseId = source.CourseId;
                Student = source.Student;
                StudentId = source.StudentId;
                Score = source.Score;
                IsNew = source.IsNew;
            }
        }
    }
}
