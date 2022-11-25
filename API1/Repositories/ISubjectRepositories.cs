using API1.Dto.Subject;
using API1.Models;

namespace API1.Repositories
{
    public interface ISubjectRepositories
    {
        Subject GetSubjectById(int id);
        List<Subject> GetSubjects();
        void CreateSubject(Subject subject);
        void UpdateSubject(UpdateSubjectDto newSubject, int oldSubjectId);
        void DeleteSubject(int id);
    }
}
