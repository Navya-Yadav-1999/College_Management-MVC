using CollegeManagement.DataBase;
using CollegeManagement.Models.DataModel;

namespace CollegeManagement.Repository
{
    public class TeacherRepository:ITeacherRepository
    {
        private readonly CollegeManagementContext _db;
        public TeacherRepository(CollegeManagementContext db)
        {
            _db = db;
        }
        public int Create(Teacher teacher)
        {
            _db.Teacher.Add(teacher);
            int rowsAffected = _db.SaveChanges();
            return rowsAffected;
        }
        public int Update(Teacher teacher)
        {
            var s = _db.Teacher.Where(i => i.Id == teacher.Id).FirstOrDefault();
            s.FirstName = teacher.FirstName;
            s.LastName = teacher.LastName;
            s.Address1 = teacher.Address1;
            s.Address2 = teacher.Address2;
            s.City = teacher.City;
            s.State = teacher.State;
            //s = _mapper.Map<Student>(student);

            _db.Update(s);
            int rowsAffected = _db.SaveChanges();
            return rowsAffected;

        }
        public int Delete(int id)
        {
            var teacher = _db.Teacher.Where(i => i.Id == id).FirstOrDefault();
            _db.Remove(teacher);
            int rowsAffected = _db.SaveChanges();
            return rowsAffected;

        }
        public Teacher Get(int id)
        {
            var teacher = _db.Teacher.Where(i => i.Id == id).FirstOrDefault();
            return teacher;
        }
        public Teacher GetTeacher(int userid)
        {
            var teacher = _db.Teacher.Where(i => i.UserId == userid).FirstOrDefault();
            return teacher;
        }
        public List<Teacher> GetAll()
        {
            var teacher = _db.Teacher.ToList();
            return teacher;
        }
        public List<Teacher> GetTeacher(string terSearch)
        {
            List<Teacher> terquery = new List<Teacher>();
            if (!string.IsNullOrEmpty(terSearch))
            {
                terquery = _db.Teacher.Where(x => x.FirstName.Contains(terSearch) || x.LastName.Contains(terSearch)).ToList();

            }
            else
            {
                terquery = (from x in _db.Teacher select x).ToList();

            }
            return terquery.ToList();
        }
    }
}
