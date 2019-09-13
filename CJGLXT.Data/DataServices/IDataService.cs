using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.Data.Data;

namespace CJGLXT.Data.DataServices
{
    public interface IDataService: IDisposable
    {
        Task<Student> GetStudentAsync(string id);
        Task<IList<Student>> GetStudentsAsync();
        Task<int> AddOrUpdateStudentAsync(Student student);
        Task<int> DeleteStudentAsync(Student student);

        Task<Teacher> GetTeacherAsync(string id);
        Task<IList<Teacher>> GetTeachersAsync();
        Task<int> AddOrUpdateTeacherAsync(Teacher teacher);
        Task<int> DeleteTeacherAsync(Teacher teacher);

        Task<Course> GetCourseAsync(int id);
        Task<IList<Course>> GetCoursesAsync();
        Task<int> AddOrUpdateCourseAsync(Course course);
        Task<int> DeleteCourseAsync(Course course);

        Task<CourseRecord> GetCourseRecordAsync(int cid, string sid);
        Task<IList<CourseRecord>> GetStudentCourseRecordsAsync(string sid);
        Task<IList<CourseRecord>> GetCourseRecordsAsync(int cid);
        Task<IList<CourseRecord>> GetCourseRecordsAsync();
        Task<int> AddCourseRecordAsync(CourseRecord record);
        Task<int> UpdateCourseRecordAsync(CourseRecord record);
        Task<int> DeleteCourseRecordAsync(CourseRecord record);

        Task<StudentEvaluation> GetStudentEvaluationAsync(string tid, string sid);
        Task<StudentEvaluation> GetStudentEvaluationsAsync(string tid);
        Task<int> AddStudentEvaluationAsync(StudentEvaluation evaluation);
        Task<int> UpdateStudentEvaluationAsync(StudentEvaluation evaluation);
        Task<int> DeleteStudentEvaluationAsync(StudentEvaluation evaluation);

        Task<TeacherEvaluation> GetTeacherEvaluationAsync(string tid, string sid);
        Task<TeacherEvaluation> GetTeacherEvaluationsAsync(string sid);
        Task<int> AddTeacherEvaluationAsync(TeacherEvaluation evaluation);
        Task<int> UpdateTeacherEvaluationAsync(TeacherEvaluation evaluation);
        Task<int> DeleteTeacherEvaluationAsync(TeacherEvaluation evaluation);
    }
}
