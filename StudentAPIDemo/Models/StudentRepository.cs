namespace StudentAPIDemo.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

      

        public IEnumerable<Student> FemaleStudents()
        {
            return this.GetAll().Where(students => students.Gender.ToUpper() == "F");

        }

        public IEnumerable<Student> GetAll()
        {
           var students = appDbContext.Students;
            return students;
        }

      
        public IEnumerable<Student> MaleStudents()
        {
            return this.GetAll().Where(students => students.Gender.ToUpper() == "M");
        }

        public IEnumerable<Student> StudentsWithS()
        {
            return this.GetAll().Where(students => students.FirstName.ToUpper() == "S");
        }

        public IEnumerable<Student> TeamA()
        {
            return this.GetAll().Where(students => students.TeamName.ToUpper() == "A");
        }

        public IEnumerable<Student> TeamB()
        {
            return this.GetAll().Where(students => students.TeamName.ToUpper() == "B");
        }

        public IEnumerable<Student> TeamC()
        {
            return this.GetAll().Where(students => students.TeamName.ToUpper() == "C");
        }

        public IEnumerable<Student> TeamD()
        {
            return this.GetAll().Where(students => students.TeamName.ToUpper() == "D");
        }
        public Student InsertStudent(Student student)
        {
            var entry = this.appDbContext.Students.Add(student);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }



        public Student UpdateStudent( Student student)
        {

            var entry = this.appDbContext.Students.Update(student);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }

        public Student DeleteStudent(int studentID)
        {
            var student = GetAll().FirstOrDefault(student => student.StudentID == studentID);
            var entry = this.appDbContext.Students.Remove(student);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }

    }
}
