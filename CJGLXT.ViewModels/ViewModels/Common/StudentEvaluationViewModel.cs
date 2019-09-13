using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;

namespace CJGLXT.ViewModels.ViewModels.Common
{
    public class StudentEvaluationViewModel:GenericDetailsViewModel<StudentEvaluationModel>
    {
        public IStudentEvaluationService StudentEvaluationService { get; }

        public StudentEvaluationViewModel(IDialogService dialogService,IStudentEvaluationService studentEvaluationService) : base(dialogService)
        {
            StudentEvaluationService = studentEvaluationService;
        }

        public override bool ItemIsNew { get; }
        protected override Task<bool> SaveItemAsync(StudentEvaluationModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> DeleteItemAsync(StudentEvaluationModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> ConfirmDeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
