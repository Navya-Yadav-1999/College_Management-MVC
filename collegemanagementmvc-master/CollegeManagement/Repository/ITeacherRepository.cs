using CollegeManagement.Models.DataModel;

namespace CollegeManagement.Repository
{
    public interface ITeacherRepository
    {
        int Create(Teacher teacher);
        int Update(Teacher teacher);
        int Delete(int id);
        Teacher Get(int id);

        List<Teacher> GetAll();
        Teacher GetTeacher(int userid);

        List<Teacher> GetTeacher(string terSearch);
    }
}
