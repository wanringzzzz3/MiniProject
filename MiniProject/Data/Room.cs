using MiniProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public partial class Room : StoredModelBase
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }
        [Display(Name = "Room Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Room Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Room Description")]
        public string Description { get; set; }
        [Required]
        public int Room_Status { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////
        //Foreign Keys
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
