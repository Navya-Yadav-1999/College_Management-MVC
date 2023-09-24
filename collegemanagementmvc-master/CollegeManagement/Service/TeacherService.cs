using CollegeManagement.Models.DataModel;
using CollegeManagement.Models.ViewModel;
using CollegeManagement.Repository;

namespace CollegeManagement.Service
{
    public class TeacherService:ITeacherService
    {
        private readonly ITeacherRepository _teacherrepository;
        private readonly IUserRepository _userRepository;
        public TeacherService(ITeacherRepository teacherRepository, IUserRepository userRepository)
        {
            _teacherrepository = teacherRepository;
            _userRepository = userRepository;
        }
        public bool Save(TeacherViewModel teacher)
        {

            if (teacher.City.ToLower() != "vizag")
            {
                throw new Exception("Teacher must be from vizag city");
            }
            var std = new Teacher()
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Address1 = teacher.Address1,
                Address2 = teacher.Address2,
                City = teacher.City,
                State = teacher.State
            };
            int rowsAffected = 0;
            if (teacher.Id > 0)
            {
                rowsAffected = _teacherrepository.Update(std);
            }
            else
            {
                var user = new User { EmailId = teacher.EmailId, UserType = "Teacher", UserPassword = "Miracle@123", IsActive = true };
                _userRepository.Create(user);

                user = _userRepository.Get(user.EmailId);
                std.UserId = user.Id;
                rowsAffected = _teacherrepository.Create(std);
            }
            return rowsAffected > 0;

        }
        public List<Teacher> Details()
        {
            List<Teacher> rows = new List<Teacher>(); ;
            rows = _teacherrepository.GetAll();
            return rows;

        }
        public Teacher Get(int Id)
        {
            var teacher = _teacherrepository.Get(Id);
            var std = new Teacher()
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Address1 = teacher.Address1,
                Address2 = teacher.Address2,
                City = teacher.City,
                State = teacher.State
            };
            return std;
        }
        public bool Delete(int Id)
        {
            int rowsAffected = 0;

            if (Id > 0)
            {
                rowsAffected = _teacherrepository.Delete(Id);
            }
            return rowsAffected > 0;
        }

        public bool Edit(Teacher teacher)
        {
            var std = _teacherrepository.Update(teacher);
            return std > 0;
        }
        public Teacher GetTeacher(int userid)
        {
            var teacher = _teacherrepository.GetTeacher(userid);
            var std = new Teacher()
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Address1 = teacher.Address1,
                Address2 = teacher.Address2,
                City = teacher.City,
                State = teacher.State,
                UserId = teacher.UserId
            };
            return std;
        }
        public List<Teacher> GetTeacher(string terSearch)
        {
            var teacher = _teacherrepository.GetTeacher(terSearch);
            return teacher;

        }
    }
}
