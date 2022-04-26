using Examino.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Examino.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Raport> Raports { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ApplicationUser
            modelBuilder.Entity<ApplicationUser>()
             .HasDiscriminator<string>("UserType")
             .HasValue<Patient>("Patient")
             .HasValue<Doctor>("Doctor");

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Primary key
                b.HasKey(u => u.Id);

                // Maps to the AspNetUsers table
                b.ToTable("Users");

                // A concurrency token for use with the optimistic concurrency checking
                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                // Limit the size of columns to use efficient database types
                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);

                // The relationships between User and other entity types
                // Note that these relationships are configured with no navigation properties

                // Each User can have many UserClaims
                b.HasMany<IdentityUserClaim<Guid>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

                // Each User can have many UserLogins
                b.HasMany<IdentityUserLogin<Guid>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

                // Each User can have many UserTokens
                b.HasMany<IdentityUserToken<Guid>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany<IdentityUserRole<Guid>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            });

            //table AspNetUserClaims
            modelBuilder.Entity<IdentityUserClaim<Guid>>(b =>
            {
                // Primary key
                b.HasKey(uc => uc.Id);
                // Maps to the AspNetUserClaims table
                b.ToTable("UserClaims");
            });
            //table AspNetUserLogins
            modelBuilder.Entity<IdentityUserLogin<Guid>>(b =>
            {
                // Composite primary key consisting of the LoginProvider and the key to use
                // with that provider
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
                // Limit the size of the composite key columns due to common DB restrictions
                b.Property(l => l.LoginProvider).HasMaxLength(128);
                b.Property(l => l.ProviderKey).HasMaxLength(128);

                // Maps to the AspNetUserLogins table
                b.ToTable("UserLogins");

            });
            //table AspNetUserTokens
            modelBuilder.Entity<IdentityUserToken<Guid>>(b =>
            {
                // Composite primary key consisting of the UserId, LoginProvider and Name
                b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });


                // Maps to the AspNetUserTokens table
                b.ToTable("UserTokens");

            });
            //table AspNetUserRoles
            modelBuilder.Entity<IdentityUserRole<Guid>>(b =>
            {
                // Primary key
                b.HasKey(r => new { r.UserId, r.RoleId });
                // Maps to the AspNetUserRoles table
                b.ToTable("UserRoles");
            });
            //Roles
            modelBuilder.Entity<IdentityRole<Guid>>(b =>
            {
                // Primary key
                b.HasKey(r => r.Id);


                // A concurrency token for use with the optimistic concurrency checking
                b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                // Limit the size of columns to use efficient database types
                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.NormalizedName).HasMaxLength(256);

                // Maps to the AspNetRoles table
                b.ToTable("Roles");
                // The relationships between Role and other entity types
                // Note that these relationships are configured with no navigation properties

                // Each Role can have many entries in the UserRole join table
                b.HasMany<IdentityUserRole<Guid>>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany<IdentityRoleClaim<Guid>>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });
            //RoleClaim
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(b =>
            {
                // Primary key
                b.HasKey(rc => rc.Id);
                // Maps to the AspNetRoleClaims table
                b.ToTable("RoleClaims");
            });
        }
    }
}
