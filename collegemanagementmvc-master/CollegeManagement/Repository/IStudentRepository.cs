using CollegeManagement.Models.DataModel;

namespace CollegeManagement.Repository
{
    public interface IStudentRepository
    {
        int Create(Student student);
        int Update(Student student);
        int Delete(int id);
        Student Get(int id);

        List<Student> GetStudent(string stdSearch);

        List<Student> GetAll();

        Student GetStudent(int userid);
    }
}
