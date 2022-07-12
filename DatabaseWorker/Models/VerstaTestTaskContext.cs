﻿using Microsoft.EntityFrameworkCore;

namespace DatabaseWorker.Models
{
    internal class VerstaTestTaskContext : DbContext
    {
        public DbSet<DeliveryOrder> DeliveryOrderForms { get; set; } = null!;
        public VerstaTestTaskContext(DbContextOptions<VerstaTestTaskContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        public void EnsureCreated()
        {
            Database.EnsureCreated();
        }
    }
}
