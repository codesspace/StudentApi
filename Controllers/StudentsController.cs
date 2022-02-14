using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public readonly StudentsAPiContext myConnect;
        public StudentsController(StudentsAPiContext initConnect )
        {
            myConnect = initConnect;
        }
        IEnumerable<Student> students = new List<Student>();
        
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            var students = myConnect.Students.ToList(); //select * from Students
            if (students == null) {
                return NotFound();
            }

            List<Student> studentList = new List<Student>();

            foreach (var stud in students) //select * from Students order by Id
            {
                Student myStudent = new Student 
                {
                    Id = stud.Id,
                    Name = stud.Name,
                    Gender = stud.Gender,
                    Class = stud.Class,
                };
                studentList.Add(myStudent);
            }
            return Ok(studentList);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Student>> GetByID(int id)
        {
            return Ok(myConnect.Students.FirstOrDefault(s=>s.Id==id));
        }

        [HttpGet("GetByName")]
        public ActionResult<IEnumerable<Student>> GetByName(string name)
        {
            //check if name is null
            if (name == null) 
            {
                return BadRequest();
            }
            return Ok(myConnect.Students.FirstOrDefault(s=>s.Name==name));
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            Student newStudent = new Student
            {
                Name = student.Name,
                Gender = student.Gender,
                Class = student.Class,
            };
            myConnect.Students.Add(newStudent);
            myConnect.SaveChanges();

            return Ok(newStudent);
        }
        [HttpPut]
        public ActionResult<Student> UpdateStudent(Student student)
        {
            var update = myConnect.Students.FirstOrDefault(s => s.Id == student.Id); //select * from Students where Id=student.Id;

            if (update == null)//check if student with id is available 
            {
                return NotFound("Student not Found");
            }

            update.Name = student.Name;
            update.Gender = student.Gender; 
            update.Class = student.Class;

            myConnect.Students.Update(update);
            myConnect.SaveChanges();

            return Ok(update);
        }
    }
}
