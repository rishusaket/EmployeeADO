using CustomFilterExample;
using EmployeeADO.EmployeeEntity;
using EmployeeADO.EmployeeModelBinder;
using EmployeeADO.EmplyeeBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace EmployeeADO.Controllers
{
    [CustomFilter]
    public class EmployeeController : Controller
    {
        private readonly EmployeeBusiness employeeBusiness = new EmployeeBusiness();

        public ActionResult Index(string search, int? page)
        {

            IEnumerable<Employee> employee = employeeBusiness.Display();
            return View(employee.Where(x => x.name.StartsWith(search ?? "")).ToPagedList(page ?? 1,3));
            //return View(search != null ? employee.Where(x => x.name.StartsWith(search)) : employee);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create([ModelBinder(typeof(EmployeeModelBinderClass))] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeBusiness.addEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            List<Employee> employees = employeeBusiness.Display().ToList();
            Employee employee = employees.SingleOrDefault(x => x.Id == id);
            return View(employee);
        }
        public ActionResult Delete(int id)
        {
            employeeBusiness.deleteEmployee(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            List<Employee> employees = employeeBusiness.Display().ToList();
            Employee employee = employees.SingleOrDefault(x => x.Id == id);
            ViewBag.gender = employee.gender.Equals("Male") ? true : false;
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,name,gender,location")]Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeBusiness.EditEmployee(employee);
            }

            return RedirectToAction("Index");
        }
        public JsonResult IsLocationAvailable(string location)
        {
            return Json(!employeeBusiness.isLocationAvailable(location),JsonRequestBehavior.AllowGet);
        }
    }
}
