using CollegeManagement.Models.DataModel;

namespace CollegeManagement.Repository
{
    public interface IUserRepository
    {
        int Create(User user);
        User Get(string emailId, string password);

        User Get(string emailId);
    }
}
