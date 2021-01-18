using Microsoft.EntityFrameworkCore;

namespace MediatRDemo.Data
{
    public class ContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData
            (
                new Contact { Id = 1, FirstName = "Steve", LastName = "Michelotti" },
                new Contact { Id = 2, FirstName = "Bill", LastName = "Gates" },
                new Contact { Id = 3, FirstName = "Satya", LastName = "Nadella" }
            );
        }
    }

    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}