using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MiniProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyDataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyDataContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }

                context.Users.AddRange(
                    new User
                    {
                        Full_Name = "admin",
                        Username = "admin",
                        Password = "VLh8i+x6A8Ari0evdkBBp+69TipuH0iy:1000:dbuGd7eS6gOMVAPjsr5ozmrS6s0fOTm8",
                        Email = "admin@gmail.com",
                        User_Phone = "0642235450",
                        Company = "BRISSWELL Ltd.",
                        Status = 0,
                        Created_Date = DateTime.Now
                    },
                    new User
                    {
                        Full_Name = "John",
                        Username = "johnbris",
                        Password = "VLh8i+x6A8Ari0evdkBBp+69TipuH0iy:1000:dbuGd7eS6gOMVAPjsr5ozmrS6s0fOTm8",
                        Email = "johnbris@gmail.com",
                        User_Phone = "0642235452",
                        Company = "BRISSWELL Ltd.",
                        Status = 1,
                        Created_Date = DateTime.Now
                    },
                    new User
                    {
                        Full_Name = "Dave",
                        Username = "davebris",
                        Password = "VLh8i+x6A8Ari0evdkBBp+69TipuH0iy:1000:dbuGd7eS6gOMVAPjsr5ozmrS6s0fOTm8",
                        Email = "davebris@gmail.com",
                        User_Phone = "0642235452",
                        Company = "YOUNET Ltd.",
                        Status = 1,
                        Created_Date = DateTime.Now
                    }
                );

                context.Rooms.AddRange(
                    new Room
                    {
                        Name = "Hall Front - 3F",
                        Description = "AC, Wifi, Snack",
                        Room_Status = 1,
                        Status = 1,
                        Created_Date = DateTime.Now
                    },
                    new Room
                    {
                        Name = "Hall - 3F",
                        Description = "AC, Wifi, Desk, Snack",
                        Room_Status = 1,
                        Status = 1,
                        Created_Date = DateTime.Now
                    },
                    new Room
                    {
                        Name = "Room 4A - 4F",
                        Description = "AC, TV, Wifi, Desk, Snack",
                        Room_Status = 1,
                        Status = 1,
                        Created_Date = DateTime.Now
                    },
                    new Room
                    {
                        Name = "Hall - 4F",
                        Description = "AC, Wifi, Desk, Snack",
                        Room_Status = 0,
                        Status = 1,
                        Created_Date = DateTime.Now
                    },
                    new Room
                    {
                        Name = "Hall - 6F",
                        Description = "AC, Wifi, Desk, Snack",
                        Room_Status = 1,
                        Status = 1,
                        Created_Date = DateTime.Now
                    },
                    new Room
                    {
                        Name = "Room 64 - 6F",
                        Description = "AC, TV, Wifi, Desk, Snack",
                        Room_Status = 0,
                        Status = 1,
                        Created_Date = DateTime.Now
                    },
                    new Room
                    {
                        Name = "Room 52 - 5F",
                        Description = "AC, TV, Wifi, Desk, Snack",
                        Room_Status = 1,
                        Status = 1,
                        Created_Date = DateTime.Now
                    },
                    new Room
                    {
                        Name = "Room 43 - 4F",
                        Description = "AC, TV, Wifi, Desk, Snack",
                        Room_Status = 1,
                        Status = 1,
                        Created_Date = DateTime.Now
                    }
                );
                
                //context.Bookings.AddRange(
                //    new Booking
                //    {
                //        User_Full_Name = "John",
                //        User_Company = "BRISSWELL"
                //        Status = 1,
                //        Created_Date = DateTime.Now
                //    },
                //);

                context.SaveChanges();
            }
        }
    }
}