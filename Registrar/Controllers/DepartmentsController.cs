using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Registrar.Controllers
{
  public class DepartmentsController : Controller
  {
    private readonly RegistrarContext _db;
    public DepartmentsController(RegistrarContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Department> model = _db.Departments.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Department department)
    {
      _db.Departments.Add(department);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisDepartment = _db.Departments
      .Include(department => department.Students)
      .Include(department => department.Courses)
      .FirstOrDefault(course => course.DepartmentId == id);
      return View(thisDepartment);
    }
    public ActionResult Edit(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }
    [HttpPost]
    public ActionResult Edit(Department department)
    {
  
      _db.Entry(department).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      _db.Departments.Remove(thisDepartment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }  

}
// public ActionResult AddStudent(int id)
    // {
    //   var thisDepartment = _db.Departments.FirstOrDefault(departments => departments.DepartmentId == id);
    //   ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "StudentName");
    //   return View(thisDepartment);
    // }
    // [HttpPost]
    // public ActionResult AddStudent(Department department, int StudentId)
    // {
    //   if (StudentId != 0)
    //   {
    //     _db.DepartmentCourseStudent.Add(new DepartmentCourseStudent() {StudentId = StudentId, DepartmentId = department.DepartmentId});
    //   }
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
    // public ActionResult AddCourse(int id)
    // {
    //   var thisDepartment = _db.Departments.FirstOrDefault(departments => departments.DepartmentId == id);
    //   ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
    //   return View(thisDepartment);
    // }
    // [HttpPost]
    // public ActionResult AddCourse(Department department, int CourseId)
    // {
    //   if (CourseId != 0)
    //   {
    //     _db.DepartmentCourseStudent.Add(new DepartmentCourseStudent() {CourseId = CourseId, DepartmentId = department.DepartmentId});
    //   }
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
    // [HttpPost]
    // public ActionResult DeleteCourse(int joinId)
    // {
    //   var joinEntry = _db.DepartmentCourseStudent.FirstOrDefault(entry => entry.DepartmentCourseStudentId == joinId);
    //   _db.DepartmentCourseStudent.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
    // [HttpPost]
    // public ActionResult DeleteStudent(int joinId)
    // {
    //   var joinEntry = _db.DepartmentCourseStudent.FirstOrDefault(entry => entry.DepartmentCourseStudentId == joinId);
    //   _db.DepartmentCourseStudent.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    //}