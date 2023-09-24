using CollegeManagement.DataBase;
using CollegeManagement.Models.DataModel;

namespace CollegeManagement.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly CollegeManagementContext _db;
        public UserRepository(CollegeManagementContext db)
        {
            _db = db;
        }
        public int Create(User user)
        {
            _db.users.Add(user);
            int rowsAffected = _db.SaveChanges();
            return rowsAffected;
        }
        public User Get(string emailId, string password)
        {
            var user = _db.users.Where(i => i.EmailId == emailId && i.UserPassword == password).FirstOrDefault();
            return user;
        }
        public User Get(string emailId)
        {
            var user = _db.users.Where(i => i.EmailId == emailId).FirstOrDefault();
            return user;
        }
    }
}
