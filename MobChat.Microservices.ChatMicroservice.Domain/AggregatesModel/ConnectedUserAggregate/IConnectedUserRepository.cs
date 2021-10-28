using MobChat.Common.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ConnectedUserAggregate
{
    public interface IConnectedUserRepository : IRepository<Guid, ConnectedUser>
    {
        Task DeleteConnectedUserAsync(Guid userId);
        Task<ConnectedUser> GetConnectedUserByUserIdAsync(Guid userId);
        Task<bool> IsUserConnected(Guid userId);
    }
}
