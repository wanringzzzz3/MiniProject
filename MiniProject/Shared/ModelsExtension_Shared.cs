using MiniProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public partial class Room
    {
        public IEnumerable<Booking> ValidBookings()
        {
            return Bookings.Where(e => e.IsValid());
        }
        public bool IsValid()
        {
            return this.Status == (int)EntityStatus.Visible;
        }

        public bool Active()
        {
            return this.Room_Status == (int)EntityActiveStatus.Active;
        }

        public bool IsActiveChecked(int status)
        {
            return this.Room_Status == status;
        }

        public string RoomStatusByDate(DateTime start, DateTime end)
        {
            if (!this.Active())
                return "Not available";

            var bookings = this.Bookings;
            var a = bookings.Where(e => e.CheckBookingByDate(start, end));

            return a.Any() ? "Provisional" : "Available";
        }

        #region Enums

        public string Get_RoomStatusEnum()
        {
            var s = Room_Status.ToString();
            switch (Room_Status)
            {
                case (int)EntityStatus.Visible: s = "Active"; break;
                case (int)EntityStatus.Invisible: s = "Inactive"; break;
            }
            return s;
        }
        public string Get_RoomStatusEnumWithColor()
        {
            var s = Room_Status.ToString();
            switch (Room_Status)
            {
                case (int)EntityStatus.Visible: s = "<span class='active'>Active</span>"; break;
                case (int)EntityStatus.Invisible: s = "<span class='inactive'>Inactive</span>"; break;
            }
            return s;
        }
        #endregion
    }
    public partial class Booking
    {
        public bool IsValid()
        {
            return this.Status == (int)EntityStatus.Visible;
        }

        public bool CheckBookingByDate(DateTime? Start_Date = null, DateTime? End_Date = null)
        {
            var Start = Start_Date ?? DateTime.Now;
            var End = End_Date ?? DateTime.Now;
            return CompareDate(this.StartTime, this.EndTime, Start, End);
        }
        private bool CompareDate(DateTime startDate, DateTime endDate, DateTime Start_Date, DateTime End_Date)
        {
            return startDate < Start_Date && Start_Date < endDate ||
                   startDate < End_Date && End_Date <= endDate ||
                   Start_Date < startDate && End_Date > endDate ||
                   startDate < End_Date && Start_Date < endDate;
        }

        public bool SearchByString(string name)
        {
            return User_Full_Name.Convert_Search_String().Contains(name) ||
                   User_Company.Convert_Search_String().Contains(name) ||
                   User_Phone.Convert_Search_String().Contains(name) ||
                   User_Email.Convert_Search_String().Contains(name);
        }
    }

    public partial class User
    {
        public bool IsValid()
        {
            return this.Status == (int)EntityStatus.Visible;
        }
    }
}
