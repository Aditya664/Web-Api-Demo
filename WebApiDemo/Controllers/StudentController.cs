using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class StudentController : ApiController
    {
        List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "Aditya",
                LastName = "Deshmukh",
                ClassName = "BCS",
                Email = "a@mail.com",
                MobileNo = 10101010,
            },
            new Student
            {
                Id = 2,
                FirstName = "Atharav",
                LastName = "Deshmukh",
                ClassName = "BSC",
                Email = "a@mail.com",
                MobileNo = 20202020,
            },
            new Student
            {
                Id = 3,
                FirstName = "karn",
                LastName = "Pawar",
                ClassName = "BCOM",
                Email = "k@mail.com",
                MobileNo = 0000000,
            },
        };

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return students.ToList();
        }


        [HttpGet]
        public Student GetStudentByID(int id)
        {
            return students.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IEnumerable<Student> PostStudent(Student student)
        {
            if(student == null)
            {
                throw new Exception();
            }
            else
            {
                students.Add(student);  
                return students;
            }
        }

        [HttpPut]
        public Student PutStudent(int id,Student student)
        {
            if (student == null)
            {
                throw new Exception();
            }
            else
            {
                Student stud = students.FirstOrDefault(s => s.Id == student.Id);
                stud.Id = student.Id;
                stud.FirstName = student.FirstName;
                stud.LastName = student.LastName;
                stud.ClassName = student.ClassName;
                stud.Email = student.Email;
                stud.MobileNo = student.MobileNo;
                return stud;
            }

        }
        [HttpDelete]
        public IEnumerable<Student> DeleteStudent(int id)
        {
            students.RemoveRange(0, id);
            return students.ToList();
        }

    }
}