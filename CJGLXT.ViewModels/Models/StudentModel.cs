using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.Models
{
    public class StudentModel:ObservableObject
    {
        public string StudentId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public static StudentModel CreateEmpty() => new StudentModel { StudentId = null, IsEmpty = true };

        public bool IsNew => string.IsNullOrWhiteSpace(StudentId);

        public override void Merge(ObservableObject source)
        {
            if (source is StudentModel model)
            {
                Merge(model);
            }
        }

        public void Merge(StudentModel source)
        {
            if (source != null)
            {
                StudentId = source.StudentId;
                Name = source.Name;
                Password = source.Password;
                Age = source.Age;
                Sex = source.Sex;
            }
        }
    }
}
