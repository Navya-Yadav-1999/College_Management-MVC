using CollegeManagement.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Service
{
    public interface IUserService
    {
        bool Save(User user);

        bool IsValidUser(string emailId, string password);

        User Get(string emailId);
    }
}
