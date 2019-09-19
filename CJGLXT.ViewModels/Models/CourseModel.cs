using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.Models
{
    public class CourseModel:ObservableObject
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public static CourseModel CreateEmpty() => new CourseModel { CourseId = -1, IsEmpty = true };

        public bool IsNew => CourseId<=0;


        public override void Merge(ObservableObject source)
        {
            if (source is CourseModel model)
            {
                Merge(model);
            }
        }

        public void Merge(CourseModel source)
        {
            if (source != null)
            {
                CourseId = source.CourseId;
                Name = source.Name;
                Description = source.Description;
            }
        }
    }
}
