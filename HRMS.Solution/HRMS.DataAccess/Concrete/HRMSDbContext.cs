using HRMS.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Global Query Filters (soft delete)
            modelBuilder.Entity<Employee>()
                .HasQueryFilter(e => e.IsActive && !e.IsDeleted);

            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => r.IsActive && !r.IsDeleted);

            modelBuilder.Entity<Department>()
                .HasQueryFilter(d => d.IsActive && !d.IsDeleted);

            modelBuilder.Entity<DepartmentRole>()
                .HasQueryFilter(dr => dr.IsActive && !dr.IsDeleted);

            // Employee → Role (1 Role, birden fazla Employee)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            // Employee → Department (1 Department, birden fazla Employee)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            // DepartmentRole: Many-to-Many (Department <-> Role)
            modelBuilder.Entity<DepartmentRole>()
                .HasKey(dr => new { dr.DepartmentId, dr.RoleId });

            modelBuilder.Entity<DepartmentRole>()
                .HasOne(dr => dr.Department)
                .WithMany(d => d.DepartmentRoles)
                .HasForeignKey(dr => dr.DepartmentId);

            modelBuilder.Entity<DepartmentRole>()
                .HasOne(dr => dr.Role)
                .WithMany(r => r.DepartmentRoles)
                .HasForeignKey(dr => dr.RoleId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
