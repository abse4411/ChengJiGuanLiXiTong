using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.Models
{
    public class TeacherEvaluationModel : ObservableObject
    {
        public string TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }

        public string StudentId { get; set; }
        public StudentModel Student { get; set; }

        public string Content { get; set; }

        public static TeacherEvaluationModel CreateEmpty() => new TeacherEvaluationModel { StudentId = null, IsEmpty = true };

        public bool IsNew => string.IsNullOrWhiteSpace(StudentId);

        public override void Merge(ObservableObject source)
        {
            if (source is TeacherEvaluationModel model)
            {
                Merge(model);
            }
        }

        public void Merge(TeacherEvaluationModel source)
        {
            if (source != null)
            {
                TeacherId = source.TeacherId;
                StudentId = source.StudentId;
                Content = source.Content;
            }
        }
    }
}
