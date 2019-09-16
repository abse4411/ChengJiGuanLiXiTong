using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;

namespace CJGLXT.ViewModels.Services
{
    public interface IRankService
    {
        Task<IList<RankModel>> GetStudentRankListAsync();
    }
}
