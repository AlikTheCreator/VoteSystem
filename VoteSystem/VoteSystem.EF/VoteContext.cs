using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using VoteSystem.Data.Entities.PollAggregate;
using VoteSystem.Data.Entities.UserPolicyAggregate;
using VoteSystem.Data.Entities.RegionPolicyAggregate;
using VoteSystem.Data.Entities.VoteAggregate;

namespace VoteSystem.EF
{
    public class VoteContext : DbContext
    {
        public DbSet<Choice> Choices { get;set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<RegionPolicy> RegionPolicies { get; set; }
        public DbSet<UserPolicy> UserPolicies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Poll>().HasMany(p => p.Choices).WithRequired(c => c.Poll);
            modelBuilder.Entity<Region>().HasMany(r => r.RegionPolicies).WithRequired(p => p.Region);
            modelBuilder.Entity<User>().HasMany(u => u.UserPolicies).WithRequired(p => p.user);
            modelBuilder.Entity<Vote>();
        }
    }
}
