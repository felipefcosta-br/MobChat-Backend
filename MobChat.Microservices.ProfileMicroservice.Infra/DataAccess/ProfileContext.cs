using Microsoft.EntityFrameworkCore;
using MobChat.Microservices.ProfileMicroservice.Domain.AggregatesModel.ProfileAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobChat.Microservices.ProfileMicroservice.Infra.DataAccess
{
    public class ProfileContext : DbContext
    {
        private readonly string dbConnectionString;
        public DbSet<Profile> Profile { get; set; }

        public ProfileContext()
        {
            this.dbConnectionString = "Server=[AzureRepository]";
            Database.EnsureCreated();
        }

        public ProfileContext(string dbConnectionString)
        {
            this.dbConnectionString = dbConnectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(dbConnectionString);
        }
    }
}
