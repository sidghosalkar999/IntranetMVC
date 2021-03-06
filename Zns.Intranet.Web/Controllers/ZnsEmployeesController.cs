using System;
using log4net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zns.Intranet.Web.Models;

namespace Zns.Intranet.Web.Controllers
{
    //[HandleError(ExceptionType = typeof(OutOfMemoryException), View = "~/Views/Error/DBError.cshtml")]
    public class ZnsEmployeesController : Controller
    {
        private DbContextZns db = new DbContextZns();
        ILog log = log4net.LogManager.GetLogger("ZnsEmployeesController");

        // GET: ZnsEmployees
        public ActionResult Index()
         {
            //throw new FileNotFoundException();
            var employees = db.Employees.Include(e => e.FieldExperience);
            return View(employees.ToList());

            try
            {
                log.Error("Something went wrong when listing employee");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
               

            }
        }

        // GET: ZnsEmployees/Details/5
        public ActionResult Details(int? id)
        {
            Debug.WriteLine("Trying to get employees Information");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: ZnsEmployees/Create
        public ActionResult Create()
        {
            Debug.WriteLine("Trying to create employees");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        // POST: ZnsEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FieldExperience,PhoneNumber,Salary,BirthDate")] Employee employee)
        {
            Debug.WriteLine("Trying to create new Employee");
            if (ModelState.IsValid)
            {
                Debug.WriteLine("Trying to create new Employee");
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.FieldExperience);
            return View(employee);
        }

        // GET: ZnsEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            Debug.WriteLine("Trying to edit employees {id}");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: ZnsEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FieldExperience,PhoneNumber,Salary,BirthDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: ZnsEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            Debug.WriteLine("Trying to Delete employees {id}");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: ZnsEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /*protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            log.Error("Something Went Wrong");
            filterContext.Result = new ViewResult { ViewName = "~/Views/Error/InternalError.cshtml" };
                //RedirectToAction("Index", "Home");
        }*/
    }
}
