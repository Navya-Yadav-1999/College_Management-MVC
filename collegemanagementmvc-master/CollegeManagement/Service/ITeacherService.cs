using CollegeManagement.Models.DataModel;
using CollegeManagement.Models.ViewModel;

namespace CollegeManagement.Service
{
    public interface ITeacherService
    {

        bool Save(TeacherViewModel student);
        List<Teacher> Details();

        Teacher Get(int Id);

        List<Teacher> GetTeacher(string terSearch);
        bool Delete(int Id);

        bool Edit(Teacher teacher);
        Teacher GetTeacher(int userid);
    }
}
