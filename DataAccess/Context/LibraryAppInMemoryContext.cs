using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Context
{
    public class LibraryAppInMemoryContext : BaseDbContext
    {
        //protected IConfiguration Configuration { get; }
        //public LibraryAppInMemoryContext(DbContextOptions options, IConfiguration configuration) : base(options)
        //{
        //    Configuration= configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}

        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<Book> Books { get; set; }
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<RentedBook> RentedBooks { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //    //many  to many
        //    modelBuilder.Entity<UserRole>()
        //        .HasKey(ur => new { ur.UserId, ur.RoleId });
        //    modelBuilder.Entity<UserRole>()
        //        .HasOne(ur => ur.User)
        //        .WithMany(u => u.Roles)
        //        .HasForeignKey(ur => ur.UserId);
        //    modelBuilder.Entity<UserRole>()
        //        .HasOne(ur => ur.Role)
        //        .WithMany(r => r.Users)
        //        .HasForeignKey(ur => ur.RoleId);

        //    //many to many
        //    modelBuilder.Entity<RentedBook>()
        //        .HasKey(rb => new { rb.UserId, rb.BookId });
        //    modelBuilder.Entity<RentedBook>()
        //        .HasOne(rb => rb.User)
        //        .WithMany(u => u.Books)
        //        .HasForeignKey(rb => rb.UserId);
        //    modelBuilder.Entity<RentedBook>()
        //        .HasOne(rb => rb.Book)
        //        .WithMany(b => b.Users)
        //        .HasForeignKey(rb => rb.BookId);

        //    //one to many
        //    modelBuilder.Entity<Book>()
        //        .HasOne(b => b.Author)
        //        .WithMany(a => a.Books)
        //        .HasForeignKey(b => b.AuthorId);

        //    byte[] passwordHash, passwordSalt;

        //    HashingHelper.CreatePasswordHash("admin123", out passwordHash, out passwordSalt);
        //    modelBuilder.Entity<User>().HasData(new User { Id = 1, FirstName = "ADMİN", LastName = "ADMİN", Email = "admin@gmail.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt });
        //    modelBuilder.Entity<Role>().HasData(
        //        new Role { Id = 1, Name = "USER" },
        //        new Role { Id = 2, Name = "ADMİN" });
        //    modelBuilder.Entity<UserRole>().HasData(new UserRole { RoleId = 2, UserId = 1 });
        //}

        public LibraryAppInMemoryContext(IConfiguration configuration)
           : base( configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder.UseInMemoryDatabase("LibraryApp"));
            }
        }

    }
}
