using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ChatAggregate
{
    public interface IChatService
    {
        Task<Guid> AddChatAsync(Chat chat);
        Task<bool> UpdateChatAsync(Chat chat);
        Task<bool> DeleteChatAsync(Guid chatId);
        Task<Chat> GetChatAsync(Guid chatId);
        Task<IEnumerable<Chat>> GetChatsByMemberId(Guid memberID);
        Task<IEnumerable<Chat>> GetChatsByMembersId(Guid firstMemberID, Guid secondMemberID);
    }
}
