using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.Models
{
    public class StudentEvaluationModel:ObservableObject
    {
        public string TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }

        public string StudentId { get; set; }
        public StudentModel Student { get; set; }

        public string Content { get; set; }

        public static StudentEvaluationModel CreateEmpty() => new StudentEvaluationModel {  Teacher = null, IsEmpty = true };

        public bool IsNew { get; set; } = true;

        public override void Merge(ObservableObject source)
        {
            if (source is StudentEvaluationModel model)
            {
                Merge(model);
            }
        }

        public void Merge(StudentEvaluationModel source)
        {
            if (source != null)
            {
                TeacherId = source.TeacherId;
                StudentId = source.StudentId;
                Content = source.Content;
                IsNew = source.IsNew;
            }
        }
    }
}
