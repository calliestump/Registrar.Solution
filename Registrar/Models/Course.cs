using System.Collections.Generic;
using System;
namespace Registrar.Models
{
  public class Course
  {
    public Course()
    {
      this.Students = new HashSet<CourseStudent>();
      //this.Departments = new HashSet<DepartmentCourseStudent>();
    }
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string CourseNumber { get; set; }

    public virtual ICollection<CourseStudent> Students { get; set; }
    // public int DepartmentId { get; set ; }
    // public virtual Department Department { get; set; }
    //public virtual ICollection<DepartmentCourseStudent> Departments { get; set; }
  }
}