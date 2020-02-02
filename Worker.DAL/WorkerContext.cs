using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Worker.DAL.Entities;

namespace Worker.DAL
{
    public class WorkerContext : DbContext
    {
        public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
