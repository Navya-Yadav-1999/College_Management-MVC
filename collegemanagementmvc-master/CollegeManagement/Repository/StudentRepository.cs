using CollegeManagement.DataBase;
using CollegeManagement.Models.DataModel;

namespace CollegeManagement.Repository
{
    public class StudentRepository:IStudentRepository
    {
        //private readonly IMapper _mapper;

        private readonly CollegeManagementContext _db;
        public StudentRepository(CollegeManagementContext db)
        {
            _db = db;
            //_mapper = mapper;

        }
        public int Create(Student student)
        {
            _db.Student.Add(student);
            int rowsAffected = _db.SaveChanges();
            return rowsAffected;
        }
        public int Update(Student student)
        {
            var s = _db.Student.Where(i => i.Id == student.Id).FirstOrDefault();
            s.FirstName = student.FirstName;
            s.LastName = student.LastName;
            s.Address1 = student.Address1;
            s.Address2 = student.Address2;
            s.City = student.City;
            s.State = student.State;

            //s = _mapper.Map<Student>(student);

            _db.Update(s);
            int rowsAffected = _db.SaveChanges();
            return rowsAffected;

        }
        public int Delete(int id)
        {
            var student = _db.Student.Where(i => i.Id == id).FirstOrDefault();
            _db.Remove(student);
            int rowsAffected = _db.SaveChanges();
            return rowsAffected;

        }
        public Student Get(int id)
        {
            var student = _db.Student.Where(i => i.Id == id).FirstOrDefault();
            return student;
        }
        public Student GetStudent(int userid)
        {
            var student = _db.Student.Where(i => i.UserId == userid).FirstOrDefault();
            return student;
        }

        public List<Student> GetAll()
        {
            var student = _db.Student.ToList();
            return student;
        }
        public List<Student> GetStudent(string stdSearch)
        {
            List<Student> stdquery = new List<Student>();
            if (!string.IsNullOrEmpty(stdSearch))
            {
                stdquery = _db.Student.Where(x => x.FirstName.Contains(stdSearch) || x.LastName.Contains(stdSearch)).ToList();

            }
            else
            {
                stdquery = (from x in _db.Student select x).ToList();

            }
            return stdquery.ToList();
        }
    }
}
