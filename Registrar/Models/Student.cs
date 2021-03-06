using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Registrar.Models
{
  public class Student
  {
    public Student()
    {
      this.Courses = new HashSet<CourseStudent>();
      //this.Departments = new HashSet<DepartmentCourseStudent>();
    }
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    [DisplayName("Add Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
    public DateTime EnrollmentDate { get; set; }
    
    public ICollection<CourseStudent> Courses { get; }
    public int DepartmentId { get; set ; }
    // public virtual Department Department { get; set; }
    //public virtual ICollection<DepartmentCourseStudent> Departments { get; set; }
  }
}