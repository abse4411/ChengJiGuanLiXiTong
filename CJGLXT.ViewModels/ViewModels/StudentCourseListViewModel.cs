using System;
using System.Collections.Generic;
using System.Text;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class StudentCourseListViewModel:GenericListViewModel<CourseRecordModel>
    {
        public StudentCourseListViewModel(IDialogService dialogService) : base(dialogService)
        {
        }

        public void Load(IList<CourseRecordModel> list)
        {
            Items = list;
        }

        protected override void OnNew()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefresh()
        {
            throw new NotImplementedException();
        }

        protected override void OnDeleteSelection()
        {
            throw new NotImplementedException();
        }
    }
}
