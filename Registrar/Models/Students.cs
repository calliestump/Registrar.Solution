using System.Collections.Generic;
using System;
namespace Registrar.Models
{
  public class Student
  {
    public Student()
    {
      this.Courses = new HashSet<CourseStudent>();
    }
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    
    public ICollection<CourseStudent> Courses { get; }
  }
}