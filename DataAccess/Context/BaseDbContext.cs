using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; }
        protected BaseDbContext(IConfiguration configuration)

        {
            Configuration = configuration;

        }



        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<RentedBook> RentedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //many  to many
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(ur => ur.RoleId);

            //many to many
            modelBuilder.Entity<RentedBook>()
                .HasKey(rb => new { rb.UserId, rb.BookId });
            modelBuilder.Entity<RentedBook>()
                .HasOne(rb => rb.User)
                .WithMany(u => u.Books)
                .HasForeignKey(rb => rb.UserId);
            modelBuilder.Entity<RentedBook>()
                .HasOne(rb => rb.Book)
                .WithMany(b => b.Users)
                .HasForeignKey(rb => rb.BookId);

            //one to many
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash("admin123", out passwordHash, out passwordSalt);
            modelBuilder.Entity<User>().HasData(new User { Id = 1, FirstName = "ADMIN", LastName = "ADMIN", Email = "admin@gmail.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "USER" },
                new Role { Id = 2, Name = "ADMIN" });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { RoleId = 2, UserId = 1 });
        }
    }
}
