using HRMS.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DataAccess.Concrete
{
    public class HRMSDbContext : DbContext
    {
        public HRMSDbContext(DbContextOptions<HRMSDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DepartmentRole> DepartmentRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasQueryFilter(e => e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => r.IsActive && !r.IsDeleted);

            modelBuilder.Entity<Department>()
                .HasQueryFilter(d => d.IsActive && !d.IsDeleted);

            modelBuilder.Entity<DepartmentRole>()
                .HasQueryFilter(dr => dr.IsActive && !dr.IsDeleted);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.DepartmentRole)
                .WithMany(dr => dr.Employees)
                .HasForeignKey(e => e.DepartmentRoleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DepartmentRole>()
                .HasOne(dr => dr.Department)
                .WithMany(d => d.DepartmentRoles)
                .HasForeignKey(dr => dr.DepartmentId);

            modelBuilder.Entity<DepartmentRole>()
                .HasOne(dr => dr.Role)
                .WithMany(r => r.DepartmentRoles)
                .HasForeignKey(dr => dr.RoleId);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeCode)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
