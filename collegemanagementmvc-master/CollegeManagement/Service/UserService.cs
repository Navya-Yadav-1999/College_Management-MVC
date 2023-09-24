using CollegeManagement.Models.DataModel;
using CollegeManagement.Repository;

namespace CollegeManagement.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userrepository;
        public UserService(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }
        public bool Save(User user)
        {
            if (string.IsNullOrEmpty(user.EmailId))
            {
                throw new Exception("EmailId Should Not Be Empty");
            }
            int rowsaffected = _userrepository.Create(user);
            return rowsaffected > 0;
        }
        public bool IsValidUser(string emailId, string password)
        {
            var u = _userrepository.Get(emailId, password);
            return u != null;
        }

        public User Get(string emailId)
        {
            var user = _userrepository.Get(emailId);
            return user;
        }
    }
}
