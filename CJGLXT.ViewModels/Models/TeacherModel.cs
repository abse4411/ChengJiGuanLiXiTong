using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.Models
{
    public class TeacherModel : ObservableObject
    {
        public string TeacherId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public static TeacherModel CreateEmpty() => new TeacherModel { TeacherId = null, IsEmpty = true };

        public bool IsNew => string.IsNullOrWhiteSpace(TeacherId);

        public override void Merge(ObservableObject source)
        {
            if (source is TeacherModel model)
            {
                Merge(model);
            }
        }

        public void Merge(TeacherModel source)
        {
            if (source != null)
            {
                TeacherId = source.TeacherId;
                Name = source.Name;
                Password = source.Password;
                Age = source.Age;
                Sex = source.Sex;
            }
        }
    }
}
