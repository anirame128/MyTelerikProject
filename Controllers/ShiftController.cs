using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTelerikProject.Data;
using MyTelerikProject.Models;


namespace MyTelerikProject.Controllers
{
    public class ShiftController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShiftController(ApplicationDbContext context)
        {
            _context = context;

            
            var outdatedShifts = _context.Shifts.Where(s => s.ShiftDateTime.Day < DateTime.Now.Day).ToList();
            _context.Shifts.RemoveRange(outdatedShifts);
            _context.SaveChanges();
        }
        
        public IActionResult Index()
        {
            var shifts = _context.Shifts.ToList();
            return View(shifts);
        }
        [Authorize]
        public IActionResult CreateShift()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateShift([FromForm]Shift shift)
        {
            try
            {
                Console.WriteLine("CreateShift action called.");

                // Create a new Shift object
                

                // Check if the shift already exists
                var existingShift = _context.Shifts.FirstOrDefault(s =>
                    s.assignedToStation == shift.assignedToStation &&
                    s.ShiftDateTime == shift.ShiftDateTime);

                if (existingShift != null)
                {
                    var errorMessage = "This shift already exists.";
                    return Json(new { success = false, message = errorMessage });
                }
                if (shift.ShiftDateTime.Day < DateTime.Now.Day)
                {
                    var errorMessage = "Invalid shift";
                    return Json(new { success = false, message = errorMessage });
                }

                _context.Shifts.Add(shift);
                _context.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // Log the detailed exception message for debugging
                return Json(new { success = false, message = "An unexpected error occurred." });
            }
        }








        [HttpGet]
        public JsonResult GetShifts()
        {
            var shifts = _context.Shifts.ToList();
            return Json(shifts);
        }

        [HttpPost]
        public ActionResult GetShiftUsers(int shiftId)
        {
            // Query the Shift data based on the selected shiftId
            var shift = _context.Shifts.FirstOrDefault(s => s.Id == shiftId);
            if (shift == null)
            {
                return Json(new { success = false, message = "Shift not found." });
            }

            // Fetch the employeeNumbers from the OverTimeRequest table based on the specified criteria
            var overTimeRequests = _context.OverTimeRequests
                .Where(o =>
                    o.dateRequested == shift.ShiftDateTime.Date &&
                    o.startTime == shift.StartTime &&
                    o.endTime == shift.EndTime &&
                    o.assignedToStation == shift.assignedToStation)
                .ToList();

            // Fetch the corresponding names from the User table based on employeeNumbers
            var employeeNumbers = overTimeRequests.Select(o => o.employeeNumber).Distinct().ToList();
            var userList = _context.Users
                .Where(u => employeeNumbers.Contains(u.employeeNumber))
                .ToList();

            // Return the list of names to the client-side
            var model = userList.Select(u => new
            {
                Id = u.employeeNumber,
                firstName = u.firstName
            });

            return Json(model);
        }

        //[HttpPost]
        //public ActionResult UpdateAssignedToStation(int userId, string assignedToStation)
        //{
        //    var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        //    if (user == null)
        //    {
        //        return Json(new { success = false, message = "User not found." });
        //    }

        //    user.assignedToStation = assignedToStation;
        //    _context.SaveChanges();

        //    return Json(new { success = true });
        //}



    }
}
