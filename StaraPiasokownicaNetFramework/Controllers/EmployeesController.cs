using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StaraPiasokownicaNetFramework.Models;

namespace StaraPiasokownicaNetFramework.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Details(int id)
        {
            var empContext = new DbDataContext(); 
            var selectedEmployee = empContext.Employees.Single(emp => emp.IdEmployee == id);
            return View(selectedEmployee);
        }
    }
}