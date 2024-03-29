﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace CJGLXT.Data.DataServices.Base
{
    partial class DataServiceBase
    {
        public async Task<StudentEvaluation> GetStudentEvaluationAsync(string tid, string sid)
        {
            return await _dataSource.StudentEvaluations.Where(x => x.StudentId.Equals(sid) && x.TeacherId.Equals(tid))
                .AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<StudentEvaluation> GetStudentEvaluationsAsync(string tid)
        {
            return await _dataSource.StudentEvaluations.Where(x => x.TeacherId.Equals(tid))
                .AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<int> AddOrUpdateStudentEvaluationAsync(StudentEvaluation evaluation)
        {
            if (await _dataSource.StudentEvaluations.AsNoTracking()
                    .Where(x => x.StudentId.Equals(evaluation.StudentId) && x.TeacherId.Equals(evaluation.TeacherId))
                    .FirstOrDefaultAsync() != null)
                _dataSource.StudentEvaluations.Update(evaluation);
            else
                await _dataSource.StudentEvaluations.AddAsync(evaluation);

            return await _dataSource.SaveChangesAsync();
        }

        public async Task<int> DeleteStudentEvaluationAsync(StudentEvaluation evaluation)
        {
            _dataSource.StudentEvaluations.Remove(evaluation);
            return await _dataSource.SaveChangesAsync();
        }

        public async Task<TeacherEvaluation> GetTeacherEvaluationAsync(string tid, string sid)
        {
            return await _dataSource.TeacherEvaluations.Where(x => x.StudentId.Equals(sid) && x.TeacherId.Equals(tid))
                .AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<TeacherEvaluation> GetTeacherEvaluationsAsync(string sid)
        {
            return await _dataSource.TeacherEvaluations.Where(x => x.StudentId.Equals(sid))
                .AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<int> AddOrUpdateTeacherEvaluationAsync(TeacherEvaluation evaluation)
        {
            if (await _dataSource.TeacherEvaluations.AsNoTracking()
                    .Where(x => x.StudentId.Equals(evaluation.StudentId) && x.TeacherId.Equals(evaluation.TeacherId))
                    .FirstOrDefaultAsync() != null)
                _dataSource.TeacherEvaluations.Update(evaluation);
            else
                await _dataSource.TeacherEvaluations.AddAsync(evaluation);

            return await _dataSource.SaveChangesAsync();
        }
        public async Task<int> DeleteTeacherEvaluationAsync(TeacherEvaluation evaluation)
        {
            _dataSource.TeacherEvaluations.Remove(evaluation);
            return await _dataSource.SaveChangesAsync();
        }
    }
}
