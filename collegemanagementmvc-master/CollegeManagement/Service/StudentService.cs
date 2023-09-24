using CollegeManagement.Models.DataModel;
using CollegeManagement.Models.ViewModel;
using CollegeManagement.Repository;

namespace CollegeManagement.Service
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentrepository;
        private readonly IUserRepository _userRepository;
        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository)
        {
            _studentrepository = studentRepository;
            _userRepository = userRepository;
        }
        public bool Save(StudentViewModel student)
        {

            if (student.City.ToLower() != "vizag")
            {
                throw new Exception("Student must be from vizag city");
            }
            var std = new Student()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Address1 = student.Address1,
                Address2 = student.Address2,
                City = student.City,
                State = student.State
            };
            int rowsAffected = 0;
            if (student.Id > 0)
            {
                rowsAffected = _studentrepository.Update(std);
            }
            else
            {
                var user = new User { EmailId = student.EmailId, UserType = "Student", UserPassword = "Miracle@123", IsActive = true };
                _userRepository.Create(user);

                //user = _userRepository.Get(user.EmailId);
                std.UserId = user.Id;

                rowsAffected = _studentrepository.Create(std);
            }
            return rowsAffected > 0;

        }
        public List<Student> Details()
        {
            List<Student> rows = new List<Student>(); ;
            rows = _studentrepository.GetAll();
            return rows;

        }
        public Student Get(int Id)
        {
            var student = _studentrepository.Get(Id);
            var std = new Student()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Address1 = student.Address1,
                Address2 = student.Address2,
                City = student.City,
                State = student.State,
                UserId = student.UserId
            };
            return std;
        }
        public bool Delete(int Id)
        {
            int rowsAffected = 0;

            if (Id > 0)
            {
                rowsAffected = _studentrepository.Delete(Id);
            }
            return rowsAffected > 0;
        }
        public List<Student> GetStudent(string stdSearch)
        {
            var student = _studentrepository.GetStudent(stdSearch);
            return student;

        }
        public Student GetStudent(int userid)
        {
            var student = _studentrepository.GetStudent(userid);
            var std = new Student()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Address1 = student.Address1,
                Address2 = student.Address2,
                City = student.City,
                State = student.State,
                UserId = student.UserId
            };
            return std;
        }
        public bool Edit(Student student)
        {
            var std = _studentrepository.Update(student);
            return std > 0;
        }
    }
}
