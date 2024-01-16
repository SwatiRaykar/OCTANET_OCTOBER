using EmployeePaySlip.Interface;
using EmployeePaySlip.Models;
using EmployeePaySlip.Models.Tables;
using EmployeePaySlip.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeePaySlip.Controllers
{
    public class EmployeeController : Controller
    {
        //public readonly DataContext dataContext;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _employee;
        public EmployeeController ( IConfiguration config, IEmployeeRepository employee)
        {
           // this.dataContext = dataContext;
            _configuration = config;
            _employee = employee;
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {  DisplayAllEmployeeViewModel viewModel = new DisplayAllEmployeeViewModel();
           
            viewModel.AllEmployeeList = _employee.GetAllEmployee().ToList();
            return View(viewModel);
           // return lst;
        }

        // GET: YourController/Add
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee( AddEmpViewModel employee)
        {
            
                try
                {
                   
                   if (ModelState.IsValid)
                   {
                   // AddEmpViewModel viewModel = new AddEmpViewModel();

                    _employee.AddEmployee(employee);
                   // return RedirectToAction("AddEmployee","Employee"); // Redirect to another/Same action after successful data addition
                   }

                  return View(employee);
                }
                catch (Exception ex)
                {
                Console.WriteLine("An error occurred: " + ex.Message);
                //throw;
                }
            return RedirectToAction("AddEmployee");

        }
        public ActionResult GetEmpById(int id)
        {
            Employee employee = _employee.GetEmpById(id);
            if (employee == null)
            {
                return View(employee);
            }
            else {
                return null;//if not found
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _employee.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employee.Update(employee);
                return RedirectToAction("Details", new { id = employee.Id });
            }
            return View(employee);
        }
    }
}
