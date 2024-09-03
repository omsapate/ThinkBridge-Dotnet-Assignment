using EmployeeTaskManager.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeTaskManager.DB
{
    public class EmployeeTaskDBContext : DbContext
    {
        public EmployeeTaskDBContext(DbContextOptions<EmployeeTaskDBContext> options)
        : base(options)
        {
        }

        public DbSet<Models.Task> Task { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Documents> Documents { get; set; }
    }
}
