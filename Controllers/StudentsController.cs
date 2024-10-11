using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();

        public StudentsController()
        {
            _students.Add(new Student { Id = 1, FirstName = "John", LastName = "Edwin", Email = "john.edwin@email.com", Phone = "123-456-7890", DateOfBirth = new DateTime(2000, 10, 1) });
            _students.Add(new Student { Id = 2, FirstName = "Jane", LastName = "Annie", Email = "anniejane@email.com", Phone = "098-765-4321", DateOfBirth = new DateTime(2002, 2, 12) });
        }

        // GET api/students
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_students);
        }

        // GET api/students/5
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST api/students
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            _students.Add(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT api/students/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Email = student.Email;
            existingStudent.Phone = student.Phone;
            existingStudent.DateOfBirth = student.DateOfBirth;
            return Ok(existingStudent);
        }

        // DELETE api/students/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            _students.Remove(student);
            return NoContent();
        }
    }
}