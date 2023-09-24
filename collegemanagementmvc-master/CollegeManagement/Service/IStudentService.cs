using CollegeManagement.Models.DataModel;
using CollegeManagement.Models.ViewModel;

namespace CollegeManagement.Service
{
    public interface IStudentService
    {

        bool Save(StudentViewModel student);
        List<Student> Details();

        Student Get(int Id);

        List<Student> GetStudent(string stdSearch);

        Student GetStudent(int userid);

        bool Delete(int Id);

        bool Edit(Student student);
    }
}
