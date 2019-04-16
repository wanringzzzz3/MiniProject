namespace MiniProject.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public partial class MyDataContext : DbContext
    {
        public MyDataContext(DbContextOptions<MyDataContext> options)
            : base(options)
        {
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Room

            modelBuilder.Entity<Room>().ToTable("Rooms")
            .HasMany(e => e.Bookings)
            .WithOne(e => e.Room)
            .HasForeignKey(e => e.RoomId);

            #endregion

            #region User
            modelBuilder.Entity<User>().ToTable("Users")
            .HasMany(e => e.Bookings)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Booking>().ToTable("Bookings");

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);
            #endregion
        }
    }
}
