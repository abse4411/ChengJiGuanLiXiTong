using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.Models
{
    public class CouseRecordModel:ObservableObject
    {
        public string StudentId { get; set; }
        public StudentModel Student { get; set; }

        public int CourseId { get; set; }
        public CourseModel Course { get; set; }

        public int? Score { get; set; }

        public bool IsNew { get; set; } = true;

        public static CouseRecordModel CreateEmpty() => new CouseRecordModel { CourseId = -1, StudentId=null, IsEmpty = true };

        public override void Merge(ObservableObject source)
        {
            if (source is CouseRecordModel model)
            {
                Merge(model);
            }
        }

        public void Merge(CouseRecordModel source)
        {
            if (source != null)
            {
                CourseId = source.CourseId;
                StudentId = source.StudentId;
                Score = source.Score;
                IsNew = source.IsNew;
            }
        }
    }
}
