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
            // Employee → Role
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            // Employee → Department
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            // Role → Department
            modelBuilder.Entity<Role>()
                .HasOne(r => r.Department)
                .WithMany(d => d.Roles)
                .HasForeignKey(r => r.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
