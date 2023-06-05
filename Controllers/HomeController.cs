using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTelerikProject.Data;
using MyTelerikProject.Models;
using System.Diagnostics;
using MyTelerikProject.Models;
using Microsoft.EntityFrameworkCore;


namespace MyTelerikProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        [HttpPost]
        public IActionResult ThankYou(int employeeNumber, int shifts)
        {
            var selectedShift = _context.Shifts.FirstOrDefault(s => s.Id == shifts);
            if (selectedShift != null)
            {
                var user = _context.Users.FirstOrDefault(u => u.employeeNumber == employeeNumber);
                if (user != null)
                {
                //    var existingRequest = _context.OverTimeRequests.FirstOrDefault(r =>
                //r.employeeNumber == employeeNumber &&
                //r.dateRequested == selectedShift.shiftAvailable &&
                //r.UserId == user.Id);

                //    if (existingRequest != null)
                //    {
                //        // An overtime request with the same values already exists
                //        ViewBag.Message = "You have already signed up for this shift.";
                //    }
                //    else
                //    {
                        var overTimeRequest = new OverTimeRequest
                        {
                            employeeNumber = employeeNumber,
                            dateRequested = selectedShift.ShiftDateTime,
                            dateCreated = DateTime.Now,
                            startTime = selectedShift.StartTime,
                            endTime = selectedShift.EndTime,
                            hasBeenAssigned = false,
                            assignedToStation = selectedShift.assignedToStation,
                            UserId = user.Id
                        };
                        _context.OverTimeRequests.Add(overTimeRequest);
                        _context.SaveChanges();
                   // }
                }
                
            } else
            {
                return View("Error");
            }

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult CheckEmployeeNumber(int employeeNumber)
        {
                bool isValid = _context.Users.Any(u => u.employeeNumber == employeeNumber);
            if (isValid)
            {
                TempData["EmployeeNumber"] = employeeNumber;
            }
                return Json(new { valid = isValid });
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateHasBeenAssigned(int id, string assignedToStation)
        {
            // Retrieve the OverTimeRequest from the database
            var overtimeRequest = _context.OverTimeRequests.FirstOrDefault(r => r.Id == id);
            if (overtimeRequest == null)
            {
                return Json(new { success = false, message = "OverTimeRequest not found." });
            }

            overtimeRequest.assignedToStation = assignedToStation;
            overtimeRequest.hasBeenAssigned = true;
            _context.SaveChanges();

            return Json(new { success = true });
        }

        [Authorize]
        public IActionResult OTScheduler()
        {
            var users = _context.Users.ToList(); // Retrieve users from the database

            var model = users.Select(u => new { u.Id, u.firstName, u.lastName }).ToList();

            return View(model);
        }
    }
}