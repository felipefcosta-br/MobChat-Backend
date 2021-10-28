using MobChat.Common.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ChatAggregate
{
    public interface IChatRepository : IRepository<Guid, Chat>
    {
        Task<IEnumerable<Chat>> GetChatsByMemberId(Guid memberId);
        Task<IEnumerable<Chat>> GetChatsByMembersId(Guid firstMemberID, Guid secondMemberID);
    }
}
