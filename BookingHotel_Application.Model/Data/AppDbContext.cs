using BookingHotel_Application.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel_Application.Model.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.userId);
            modelBuilder.Entity<User>()
            .Property(u => u.passwordHash)
            .IsRequired();

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.customerId);

            modelBuilder.Entity<Staff>()
                .HasKey(s => s.staffId);

            modelBuilder.Entity<Admin>()
                .HasKey(s => s.adminId);

            modelBuilder.Entity<Countries>()
                .HasKey(c => c.countryId);

            modelBuilder.Entity<Hotel>()
                .HasKey(h => h.hotelId);

            modelBuilder.Entity<RoomType>()
                .HasKey(r => r.roomTypeId);

            modelBuilder.Entity<Room>()
                .HasKey(r => r.roomId);

            modelBuilder.Entity<Room>()
                .Property(r => r.pricePerDay)
                .HasColumnType("decimal(18,2)");
        }
    }
}
