using MobChat.Common.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.TextMessageAggregate
{
    public interface ITextMessageRepository :IRepository<Guid, TextMessage>
    {
        Task<IEnumerable<TextMessage>> GetTextMessagesByChatId(Guid chatId);
        Task<IEnumerable<TextMessage>> GetTextMessagesBySenderIdOrReceiverIdAsync(Guid id);
        Task<IEnumerable<TextMessage>> GetTextMessagesBySenderIdAndReceiverIdAsync(Guid senderId, Guid receiverId);
        Task<IEnumerable<TextMessage>> GetTextMessagesBySenderIdAsync(Guid senderId);
        Task<IEnumerable<TextMessage>> GetTextMessagesByReceiverIdAsync(Guid receiverId);
    }
}
