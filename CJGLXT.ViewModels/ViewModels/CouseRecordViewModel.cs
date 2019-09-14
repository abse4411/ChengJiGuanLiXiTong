using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class CouseRecordViewModel: GenericDetailsViewModel<CourseRecordModel>
    {
        public CouseRecordViewModel(IDialogService dialogService) : base(dialogService)
        {
        }

        public override bool ItemIsNew { get; }
        protected override Task<bool> SaveItemAsync(CourseRecordModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> DeleteItemAsync(CourseRecordModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> ConfirmDeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
