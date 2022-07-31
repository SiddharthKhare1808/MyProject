using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAPIDemo.Models;

namespace StudentAPIDemo.Controllers
{
    
    [ApiController]
    [Route("api/Student")]
    public class StudentController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly IStudentRepository studentRepository;
        public StudentController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllStudents")]

        public IActionResult GetAllStudents()
        {
            try
            {
                var students = this.studentRepository.GetAll();
                var ministudents = mapper.Map<StudentMini[]>(students);
                return Ok(ministudents);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }

        }

        
        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                var students = this.studentRepository.GetAll().FirstOrDefault(student => student.StudentID == id);
                if (students == null)
                {
                    return NotFound("Student not found");
                }
                return Ok(students);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }


        }

        [HttpGet]
        [Route("TeamA")]
        public IActionResult TeamA()
        {
            try
            {
                var students = this.studentRepository.TeamA();
                return Ok(students);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }

        }
        [HttpGet]
        [Route("TeamB")]
        public IActionResult TeamB()
        {
            try
            {
                var students = this.studentRepository.TeamB();
                return Ok(students);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpGet]
        [Route("TeamC")]
        public IActionResult TeamC()
        {
            try
            {
                var students = this.studentRepository.TeamC();
                return Ok(students);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpGet]
        [Route("TeamD")]
        public IActionResult TeamD()
        {
            try
            {
                var students = this.studentRepository.TeamD();
                return Ok(students);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpGet]
        [Route("MaleStudents")]
        public IActionResult MaleStudents()
        {
            try
            {
                var students = this.studentRepository.MaleStudents();
                return Ok(students);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }

        }
        [HttpGet]
        [Route("FemaleStudents")]
        public IActionResult FemaleStudents()
        {
            try
            {
                var students = this.studentRepository.FemaleStudents();
                return Ok(students);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
        [HttpGet]
        [Route("StudentsWithS")]
        public IActionResult StudentsWithS()
        {
            try
            {
                var students = this.studentRepository.StudentsWithS();
                return Ok(students);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
        [HttpPost]
        [Route("InsertStudent")]
        public IActionResult InsertStudent(Student student)
        {
            try
            {
                var insertedStudent = this.studentRepository.InsertStudent(student);
                return CreatedAtRoute("GetStudent", new { id = insertedStudent.StudentID }, insertedStudent);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent(Student student)
        {
            try
            {
                var updateStudent = this.studentRepository.UpdateStudent(student);
                return Ok(updateStudent);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
        [HttpDelete]
        [Route("DeleteStudent")]
        public IActionResult DeleteStudent(int studentID)
        {
            try
            {
                var deletestudent = this.studentRepository.DeleteStudent(studentID);
                return Ok(deletestudent);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

    }
}
