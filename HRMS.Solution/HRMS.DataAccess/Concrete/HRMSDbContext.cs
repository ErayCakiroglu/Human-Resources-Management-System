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

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<DepartmentRole> DepartmentRoles { get; set; } = null!;
        public DbSet<TerminationReason> TerminationReasons { get; set; } = null!;
        public DbSet<EmployeeDepartmentRole> EmployeeDepartmentRoles { get; set; } = null!;


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

            modelBuilder.Entity<EmployeeDepartmentRole>()
                .HasQueryFilter(edr => edr.IsActive && !edr.IsDeleted);

            modelBuilder.Entity<TerminationReason>()
                .HasQueryFilter(tr => tr.IsActive && !tr.IsDeleted);


            modelBuilder.Entity<EmployeeDepartmentRole>()
                .HasOne(edr => edr.Employee)
                .WithMany(e => e.EmployeeDepartmentRoles)
                .HasForeignKey(edr => edr.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeDepartmentRole>()
                .HasOne(edr => edr.Department)
                .WithMany(d => d.EmployeeDepartmentRoles)
                .HasForeignKey(edr => edr.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeDepartmentRole>()
                .HasOne(edr => edr.Role)
                .WithMany(r => r.EmployeeDepartmentRoles)
                .HasForeignKey(edr => edr.RoleId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Employee>()
                .HasOne(e => e.TerminationReason)
                .WithMany(tr => tr.Employees)
                .HasForeignKey(e => e.TerminationReasonId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeCode)
                .IsUnique();

            modelBuilder.Entity<DepartmentRole>()
                .HasOne(dr => dr.Department)
                .WithMany(d => d.DepartmentRoles)
                .HasForeignKey(dr => dr.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DepartmentRole>()
                .HasOne(dr => dr.Role)
                .WithMany(r => r.DepartmentRoles)
                .HasForeignKey(dr => dr.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}