using System.Collections.Generic;

namespace Registrar.Models
{
  public class Department
  {
    public Department()
    {
      this.Students = new HashSet<DepartmentCourseStudent>();
      this.Courses = new HashSet<DepartmentCourseStudent>();
    }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    
    public virtual ICollection<DepartmentCourseStudent> Courses { get; set; }
    public virtual ICollection<DepartmentCourseStudent> Students { get; set; }
  }
}