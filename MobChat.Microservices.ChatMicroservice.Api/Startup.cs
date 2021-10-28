using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MobChat.Microservices.ChatMicroservice.Api.Hubs;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ChatAggregate;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ConnectedUserAggregate;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.OfflineTextMessageAggregate;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.TextMessageAggregate;
using MobChat.Microservices.ChatMicroservice.Infra.DataAccess;
using MobChat.Microservices.ChatMicroservice.Infra.Repositories.Chats;
using MobChat.Microservices.ChatMicroservice.Infra.Repositories.ConnectedUsers;
using MobChat.Microservices.ChatMicroservice.Infra.Repositories.OfflineTextMessages;
using MobChat.Microservices.ChatMicroservice.Infra.Repositories.TextMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ChatHubContext>();

            services.AddSignalR();

            services.AddScoped<IChatRepository, AzureSqlServerChatRepository>();
            services.AddScoped<IChatService, ChatService>();

            services.AddScoped<ITextMessageRepository, AzureSqlServerTextMessageRepository>();
            services.AddScoped<ITextMessageService, TextMessageService>();

 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/Hubs/ChatHub");
            });
        }
    }
}
