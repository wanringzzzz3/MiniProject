using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public class LayoutModel
    {
        private readonly MyDataContext _context;
        private static readonly LayoutModel layout = new LayoutModel();

        public LayoutModel(MyDataContext context)
        {
            _context = context;
        }
        public LayoutModel()
        {
        }

        public static IEnumerable<Room> GetRooms()
        {
            return layout.GetRoomsValid();
        }

        public IEnumerable<Room> GetRoomsValid()
        {
            return _context.Rooms.Where(e => e.Status == (int)EntityStatus.Visible);
        }
    }
}
