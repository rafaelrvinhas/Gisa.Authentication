using Authentication.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infra.Data.Context
{
    public class AuthenticationContext : IdentityDbContext<Account>
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().ToTable("Account").Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<AssociateIdentification>().ToTable("AssociateIdentification");

            modelBuilder.Entity<AssociateIdentification>()
                .HasKey(m => new { m.AssociateId, m.Email, m.DocumentNumber });
        }
    }
}
