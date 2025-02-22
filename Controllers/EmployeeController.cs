using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDBContext db = new EmployeeDBContext();

        // GET: Home
        public ActionResult Index()
        {
            try
            { 

                var data = db.Employees.Where(item => item.Active == 1)
                                       .Include(e => e.Department)
                                       .Include(e => e.Gender)
                                       .ToList();
                return View(data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while fetching data.";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                var DepartementData = db.Departments.Where(item => item.Active == 1).ToList();
                ViewBag.DepartementData = new SelectList(DepartementData, "Id", "DepartmentName");

                var GenderData = db.Genders.Where(item => item.Active == 1).ToList();
                ViewBag.GenderData = new SelectList(GenderData, "Id", "GenderName");

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while creating the employee.";
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            try
            {
                var DepartementData = db.Departments.Where(item => item.Active == 1).ToList();
                ViewBag.DepartementData = new SelectList(DepartementData, "Id", "DepartmentName");

                var GenderData = db.Genders.Where(item => item.Active == 1).ToList();
                ViewBag.GenderData = new SelectList(GenderData, "Id", "GenderName");

                if (ModelState.IsValid)
                {
                    db.Employees.Add(e);
                    int status = db.SaveChanges();
                    if (status > 0)
                    {
                        ModelState.Clear();
                        TempData["response"] = "Employee Added Successfully! ";
                        return RedirectToAction("Index");
                    }
                }

                return View(e);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while creating the employee.";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var DepartementData = db.Departments.Where(item => item.Active == 1).ToList();
                ViewBag.DepartementData = new SelectList(DepartementData, "Id", "DepartmentName");

                var GenderData = db.Genders.Where(item => item.Active == 1).ToList();
                ViewBag.GenderData = new SelectList(GenderData, "Id", "GenderName");

                var data = db.Employees.Where(item => item.Id == id).FirstOrDefault();
                return View(data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while updating the employee.";
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            try
            {
                var DepartementData = db.Departments.Where(item => item.Active == 1).ToList();
                ViewBag.DepartementData = new SelectList(DepartementData, "Id", "DepartmentName");

                var GenderData = db.Genders.Where(item => item.Active == 1).ToList();
                ViewBag.GenderData = new SelectList(GenderData, "Id", "GenderName");

                if (ModelState.IsValid)
                {
                    db.Entry(e).State = EntityState.Modified;
                    int status = db.SaveChanges();
                    if (status > 0)
                    {
                        TempData["response"] = "Employee Updated Successfully! ";

                        return RedirectToAction("Index");
                    }
                }

                return View(e);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while updating the employee.";
                return View("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var data = db.Employees.FirstOrDefault(item => item.Id == id);

                if (data != null)
                {
                    db.Employees.Remove(data);
                    db.SaveChanges();

                    TempData["response"] = "Employee Deleted Successfully!";
                }
                else
                {
                    TempData["response"] = "Employee not found or already deleted!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while deleting the employee.";
                return View("Error");
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var data = db.Employees.Where(item => item.Id == id)
                                       .Include(e => e.Department)
                                       .Include(e => e.Gender)
                                       .FirstOrDefault();
                return View(data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while fetching the employee details.";
                return View("Error");
            }
        }
    }
}
