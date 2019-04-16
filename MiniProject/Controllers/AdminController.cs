using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.External;
using MiniProject.Models;
using MiniProject.Utilities;

namespace MiniProject.Controllers
{
    public class AdminController : BaseController
    {
        private readonly MyDataContext _context;

        public AdminController(MyDataContext context)
        {
            _context = context;
        }

        #region Room

        public async Task<IActionResult> RoomManage(int? page)
        {
            var rooms = _context.Rooms;

            var lastroom = rooms.LastOrDefault();
            if (lastroom != null)
                ViewData["NextRoomId"] = lastroom.Id + 1;

            return View(await PaginatedList<Room>.CreateAsync(rooms.Where(e => e.IsValid()).AsNoTracking(), page ?? 1, PageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                room.Status = (int)EntityStatus.Visible;
                room.Created_Date = DateTime.Now;

                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(RoomManage));
            }
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(RoomManage));
            }
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            room.Status = (int)EntityStatus.Invisible;
            _context.Update(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(RoomManage));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }

        #endregion

        #region Booking

        public async Task<IActionResult> BookingManage(int? page)
        {
            ViewData["Rooms"] = _context.Rooms.Where(e => e.IsValid());
            return View(await PaginatedList<Booking>
                .CreateAsync(_context.Bookings.Include(e => e.Room).Where(e => e.IsValid()).AsNoTracking(), page ?? 1, PageSize));
        }



        [HttpPost]
        public async Task<IActionResult> FilterBooking(
            int? page,
            int roomId,
            string searchName = "")
        {

            var items = _context.Bookings.Include(e => e.Room).Where(e => e.IsValid());

            if (!string.IsNullOrEmpty(searchName))
            {
                var name = searchName;
                name = name.ToLower().Convert_Chuoi_Khong_Dau();

                items = items.Where(c => c.SearchByString(searchName));
            }
            if(roomId > 0)
            {
                items = items.Where(c => c.RoomId == roomId);
            }
            //items = items.OrderByDescending(p => p.Created_Date);

            ViewData["Rooms"] = _context.Rooms.Where(e => e.IsValid());

            if (items == null)
            {
                PartialView("Search_Result/_partial_Search_Booking", items);
            }
            return PartialView("Search_Result/_partial_Search_Booking", await PaginatedList<Booking>
                .CreateAsync(items.AsNoTracking(), page ?? 1, PageSize));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBooking(Booking booking)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBooking(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(BookingManage));
            }
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            booking.Status = (int)EntityStatus.Invisible;
            _context.Update(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BookingManage));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }

        #endregion

    }
}
