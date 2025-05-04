using Labb3_ADV.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_ADV.NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonInterest>()
                .HasKey(pi => new { pi.PersonId, pi.InterestId });

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);

            modelBuilder.Entity<Link>()
                .HasOne(l => l.PersonInterest)
                .WithMany(pi => pi.Links)
                .HasForeignKey(l => new { l.PersonId, l.InterestId });

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Alice", PhoneNumber = "123456" },
                new Person { Id = 2, Name = "Bob", PhoneNumber = "654321" }
            );

            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Fotboll", Description = "Lagsport med boll" },
                new Interest { Id = 2, Title = "Gitarr", Description = "Stränginstrument" }
            );

            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { PersonId = 1, InterestId = 1 },
                new PersonInterest { PersonId = 1, InterestId = 2 },
                new PersonInterest { PersonId = 2, InterestId = 2 }
            );

            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, Url = "https://fotboll.se", PersonId = 1, InterestId = 1 },
                new Link { Id = 2, Url = "https://gitarrlektioner.com", PersonId = 1, InterestId = 2 },
                new Link { Id = 3, Url = "https://gitarrtips.nu", PersonId = 2, InterestId = 2 }
            );
        }
    }
}
