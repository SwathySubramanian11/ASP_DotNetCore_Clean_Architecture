﻿using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.DatabaseContext
{
    public class HrDatabaseContext : DbContext
    {
        public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options):base(options)
        {
        
        }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //setting up configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {   
            //All classes are of base type BaseEntity, getting all BaseEntity of state added or modified. Change tracker allows to see what is being effected on this object
            foreach(var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q=>q.State==EntityState.Added || q.State==EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                if(entry.State == EntityState.Added)
                    entry.Entity.DateCreated = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
