using MiniProject.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject.Models
{
    public partial class Booking : StoredModelBase
    {

        [Display(Name = "Booking Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:MM}")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "End Time")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:MM}")]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "Your Name")]
        [StringLength(100)]
        public string User_Full_Name { get; set; }
        [Required]
        [Display(Name = "Company")]
        [StringLength(250)]
        public string User_Company { get; set; }
        [Required]
        [Display(Name = "Email")]
        [StringLength(100)]
        [EmailAddress]
        public string User_Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(100)]
        [Phone]
        public string User_Phone { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Room")]
        public int RoomId { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////
        //Foreign Keys

        public virtual User User { get; set; }

        public virtual Room Room { get; set; }
    }
}
