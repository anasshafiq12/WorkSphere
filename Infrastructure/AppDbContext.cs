using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Holiday>  Holidays { get; set; }
        public DbSet<Activit> Activities { get; set; }
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; } 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
}
