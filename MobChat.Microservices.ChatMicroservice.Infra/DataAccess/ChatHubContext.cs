using Microsoft.EntityFrameworkCore;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ChatAggregate;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ConnectedUserAggregate;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.OfflineTextMessageAggregate;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.TextMessageAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobChat.Microservices.ChatMicroservice.Infra.DataAccess
{
    public class ChatHubContext : DbContext
    {
        private readonly string dbConnectionString;
        public DbSet<Chat> Chat { get; set; }
        public DbSet<TextMessage> TextMessage { get; set; }
        public DbSet<ConnectedUser> ConnectedUser { get; set; }
        public DbSet<OfflineTextMessage> OfflineTextMessage { get; set; }

        public ChatHubContext()
        {
            this.dbConnectionString = "Server=[AzureRepository];";
            Database.EnsureCreated();
        }

        public ChatHubContext(string dbConnectionString)
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
