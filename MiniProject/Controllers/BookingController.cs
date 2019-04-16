using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    public class BookingController : BaseController
    {
        private readonly MyDataContext _context;

        public BookingController(MyDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Rooms"] = _context.Rooms.Include(e => e.Bookings).Where(e => e.IsValid());
            return View(new Booking());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoadRoomByDate(Booking booking)
        {
            ViewData["Rooms"] = _context.Rooms.Include(e => e.Bookings).Where(e => e.IsValid());
            return PartialView("_partial_LoadRoomByDate", booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.UserId = this.UserId;
                booking.Status = (int)EntityStatus.Visible;
                booking.Created_Date = DateTime.Now;

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction("BookingManage", "Admin");
            }
            return View("BookingManage", booking);
        }
    }
}
