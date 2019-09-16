using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.Models
{
    public class RankModel:ObservableObject
    {
        public string StudentId { get; set; }

        public string Name { get; set; }

        public int MaxScore { get; set; }

        public int MinScore { get; set; }

        public double AverageScore { get; set; }

        public int Rank { get; set; }

        public IList<CourseRecordModel> CourseRecords=new List<CourseRecordModel>();
    }
}
