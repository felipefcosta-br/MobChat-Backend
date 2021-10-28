using Microsoft.EntityFrameworkCore;
using MobChat.Common.Infra.DataAccess.Repositories;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ConnectedUserAggregate;
using MobChat.Microservices.ChatMicroservice.Infra.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Infra.Repositories.ConnectedUsers
{
    public class AzureSqlServerConnectedUserRepository :
        EntityFrameworkRepositoryBase<Guid, ConnectedUser>, IConnectedUserRepository
    {
        public AzureSqlServerConnectedUserRepository()
            : base(new ChatHubContext("Server=[AzureRepository];"))
        {

        }
        public async Task DeleteConnectedUserAsync(Guid userId)
        {
            ConnectedUser connectedUser = await dbContext.Set<ConnectedUser>().FirstOrDefaultAsync(user => user.UserId == userId);
            if (connectedUser != null)
                await DeleteAsync(connectedUser.Id);
        }

        public async Task<ConnectedUser> GetConnectedUserByUserIdAsync(Guid userId)
        {
            return await dbContext.Set<ConnectedUser>().AsNoTracking().FirstOrDefaultAsync(user => user.UserId == userId);
        }

        public async Task<bool> IsUserConnected(Guid userId)
        {
            ConnectedUser connectedUser = await dbContext.Set<ConnectedUser>().AsNoTracking().FirstOrDefaultAsync(user => user.UserId == userId);
            if (connectedUser == null)
                return false;

            return true;
        }
    }
}
