using ComputerManage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComputerManage.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
        const string ROLE_ID = ADMIN_ID;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Computer>()
                .HasOne(e => e.Department)
                .WithMany(e => e.Computers)
                .HasForeignKey(e => e.DepartmentId);

            builder.Entity<Computer>()
                .HasOne(e => e.Group)
                .WithMany(e => e.Computers)
                .HasForeignKey(e => e.GroupId);

            builder.Entity<Computer>()
                .HasOne(e => e.Administrator)
                .WithMany(e => e.Computers)
                .HasForeignKey(e => e.AdministratorId);

            builder.Entity<WorkingGroup>()
                .HasOne(e => e.Department)
                .WithMany(e => e.WorkGroups)
                .HasForeignKey(e => e.DepartmentId);

            this.SeedDefaultUserRole(builder);
        }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<WorkingGroup> WorkingGroups { get; set; }
        public DbSet<Department> Departments { get; set; }
        private void SeedDefaultUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = ROLE_ID, Name = "SuperAdministrator", ConcurrencyStamp = "1", NormalizedName = "SuperAdministrator".ToUpper() },
                new IdentityRole() { Name = "Administrator", ConcurrencyStamp = "2", NormalizedName = "Administrator".ToUpper() }
                );

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser() { Id = ADMIN_ID, UserName = "admin", NormalizedUserName = "admin", PasswordHash = hasher.HashPassword(null, "P@ssw0rd"), SecurityStamp = "JBOPAV6NDGLHW27AVXZY63NQK7EMP5FK", LockoutEnabled = true }
                );

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID,
            });
        }

    }
}
