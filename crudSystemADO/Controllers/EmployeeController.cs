using crudSystemADO.Models;
using GoogleAuthentication.Services;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;


namespace crudSystemADO.Controllers
{
	public class EmployeeController : Controller
	{
        

        EmployeeDataAccessLayer employeeDataAccessLayer = null;
		public EmployeeController() {
			employeeDataAccessLayer = new EmployeeDataAccessLayer();
		}
		// GET: Student  
		public IActionResult Index()
		{
			ViewBag.Email = TempData.Peek("Email");
			var Email = ViewBag.Email;

            if (User.Identity.IsAuthenticated || Email != null)
			{
                TempData["Profile"] = User.FindFirstValue("urn:google:picture");
                IEnumerable<Employee> employees = employeeDataAccessLayer.GetAllEmployee();
                return View(employees);
            }
			else
			{
				return RedirectToAction("LoginPage", "Login");
			}
        }

		// GET: Student/Details/5  
		public ActionResult Details(int id)
		{
			Employee employee = employeeDataAccessLayer.GetEmployeeData(id);
			return PartialView("Details",employee);
		}

		// GET: Student/Create  
		public ActionResult Create()
		{
            return View();
		}

		// POST: Student/Create  
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Employee employee)
		{

			try
			{
				// TODO: Add insert logic here  
				employeeDataAccessLayer.AddEmployee(employee);
				return RedirectToAction(nameof(Index));
			}
			catch(Exception ex)
			{
				return View(ex);
			}
		}

		// GET: Student/Edit/5  
		public ActionResult Edit(int id)
		{
			Employee employee = employeeDataAccessLayer.GetEmployeeData(id);	
			return View(employee);
		}

		// POST: Student/Edit/5  
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Employee employee)
		{
			try
			{
				// TODO: Add update logic here  
				employeeDataAccessLayer.UpdateEmployee(employee);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: Student/Delete/5  
		public ActionResult Delete(int id)
		{
			Employee employee = employeeDataAccessLayer.GetEmployeeData(id);
			return PartialView("Delete",employee);
		}

		// POST: Student/Delete/5  
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(Employee employee)
		{
			try
			{
				// TODO: Add delete logic here  
				employeeDataAccessLayer.DeleteEmployee(employee.Id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
        
    }
}
