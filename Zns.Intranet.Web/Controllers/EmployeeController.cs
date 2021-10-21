using System;
using log4net;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Zns.Intranet.Web.Filters;
using Zns.Intranet.Web.Models;

namespace Zns.Intranet.Web.Controllers
{
    [LogAttribute]
    public class EmployeeController : Controller
    {
        ILog log = log4net.LogManager.GetLogger("EmployeeController");

        static List<Employee> empList = new List<Employee>()
            {
                new Employee(){ Id = 1, Name = "Sid", FieldExperience = 30 },
                new Employee(){ Id = 2, Name = "Vivek", FieldExperience = 40 },
                new Employee(){ Id = 3, Name = "Aniket", FieldExperience = 56 },
                new Employee(){ Id = 4, Name = "Abhishek", FieldExperience = 80 },
                new Employee(){ Id = 5, Name = "Rupali", FieldExperience = 90 },
                new Employee(){ Id = 6, Name = "Bhavika", FieldExperience = 78 },
            };



        // GET: Employee
        public ViewResult Welcome()
        {
            return View();
            //return "Welcome to Zensar technologies pvt ltd";
        }
        public EmptyResult Empty()
        {
            return new EmptyResult();
            //return View();
            //return "Welcome to Zensar technologies pvt ltd";
        }
        public ContentResult Content()
        {
            return new ContentResult() { Content = "Welcome to Zensar Technologies", ContentType = "Text/Html" };
        }
        public FileResult File()
        {
            return File(AppDomain.CurrentDomain.BaseDirectory + "Content/aadhar card.pdf", "application/pdf");
        }
        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            //log.Info("Trying to list down Employee");
            empList.OrderBy(e => e.Name);
            return View(empList);
        }
        [LogAttribute]
        [HttpGet]
        public ActionResult Create()
        {
            //log.Info("Trying to create new Employee");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            //log.Info("Trying to create new Employee");
            empList.Add(emp);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            //log.Info("Trying to get details of Employee");
            //log.Error("Trying to get details of Employee");
            //log.Warn("Trying to get details of Employee");
            //log.Debug("Trying to get details of Employee");
            //Get Record from DB
            var model = empList.Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //Get Record from DB
            var model = empList.Where(x => x.Id == id).FirstOrDefault();
            empList.Remove(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get Record from DB
            var model = empList.Where(x => x.Id == id).FirstOrDefault();

            return View(model); 
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            //Save record in Db
            Employee dbEmployee = empList.Where(x => x.Id == emp.Id).FirstOrDefault();
            empList.Remove(dbEmployee);
            dbEmployee = emp;
            empList.Add(dbEmployee);
            empList.OrderBy(e => e.Name);

            return RedirectToAction("Index");
      }

        [HttpGet]
        public ActionResult Html()
        {
            var model = new HtmlHelperModel() { Id = 1, Details = "Experiencing Zensar campus" };
            List<string> topics = new List<string> { "Sid", "Mvc", "Appi" };
            ViewBag.Date = topics;
            return View(model);
        }

        [HttpPost]
        public ActionResult Html(HtmlHelperModel model)
        {
            //Save DB
            return RedirectToAction("Index");
            //return View(model);
        }
    }

        public class HtmlHelperModel
        {
            public int Id { get; set; }
            public string Details { get; set; }
            public bool IsActive { get; set; }
            public string mood { get; set; }

        }
    }
