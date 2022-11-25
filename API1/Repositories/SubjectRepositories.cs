using API1.DBContext;
using API1.Dto.Subject;
using API1.Models;

namespace API1.Repositories
{
    public class SubjectRepositories : ISubjectRepositories
    {
        private readonly SchoolDBContext _context;

        public SubjectRepositories(SchoolDBContext context)
        {
            _context = context;
        }
        public Subject GetSubjectById(int id)
        {
            return _context.Subjects.Where(s => s.SubjectId == id).FirstOrDefault();
        }
        public void CreateSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }
        public List<Subject> GetSubjects()
        {
            return _context.Subjects.ToList();
        }
        public void UpdateSubject(UpdateSubjectDto newSubject, int oldSubjectId)
        {
            Subject subject = GetSubjectById(oldSubjectId);
            subject.Name = newSubject.Name;
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }
        public void DeleteSubject(int subjectId)
        {
            Subject subject = GetSubjectById(subjectId);
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
        }
    }
}
