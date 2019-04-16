using MiniProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Models
{
    public partial class User : StoredModelBase
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Full_Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Company { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        [Phone]
        public string User_Phone { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////
        //Foreign Keys
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
