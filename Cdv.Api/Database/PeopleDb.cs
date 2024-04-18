using Cdv.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cdv.Api.Database;

public class PeopleDb : DbContext
{
    public PeopleDb(DbContextOptions<PeopleDb> options) : base(options) 
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var people = modelBuilder.Entity<PersonEntity>();
        people.ToTable("Person");
        people.HasKey(pk => pk.PersonId);
        people.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
        people.Property(p => p.LastName).HasMaxLength(100).IsRequired();
        people.Property(p => p.PhoneNumber).HasMaxLength(9).IsRequired(false);
    }

    public DbSet<PersonEntity> People { get; set; }
}
