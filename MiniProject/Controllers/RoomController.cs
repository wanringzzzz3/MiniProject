using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    public class RoomController : Controller
    {
        private readonly MyDataContext _context;

        public RoomController(MyDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        //[XTAuthorize]
        public IActionResult GetAllRooms(DateTime? start, DateTime? end)
        {
            var MAX = 10;
            IEnumerable<Room> items = null;

            start = start ?? DateTime.Now;
            end = end ?? DateTime.Now.AddHours(1);

            items = _context.Rooms.Where(e => e.IsValid());
            items = items.Take(MAX);

            return Json(items.Select(r => GetRoomInfo(r, start.Value, end.Value)));
        }
        private object GetRoomInfo(Room room, DateTime start, DateTime end)
        {
            return new
            {
                id = room.Id,
                room.Name,
                RoomStatus = room.RoomStatusByDate(start, end),
                room.Description
            };
        }
    }
}