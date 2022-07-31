namespace StudentAPIDemo.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();

        IEnumerable<Student> TeamA();
        IEnumerable<Student> TeamB();
        IEnumerable<Student> TeamC();
        IEnumerable<Student> TeamD();

        IEnumerable<Student> MaleStudents();
        IEnumerable<Student> FemaleStudents();

        IEnumerable<Student> StudentsWithS();

        Student InsertStudent(Student student);

        Student UpdateStudent(Student student);
        Student DeleteStudent(int studentID);
    }
}
