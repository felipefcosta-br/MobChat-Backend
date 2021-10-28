using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.TextMessageAggregate
{
    public interface ITextMessageService
    {
        Task<bool> AddTextMessageAsync(TextMessage textMessage);
        Task<TextMessage> GetTextMessageAsync(Guid textMessageId);
        Task<IEnumerable<TextMessage>> GetTextMessagesByChatIdAsync(Guid chatId);
        Task<IEnumerable<TextMessage>> GetTextMessagseBySenderIdOrReceiverIdAsync(Guid id);
        Task<IEnumerable<TextMessage>> GetTextMessagesBySenderIdAndReceiverIdAsync(Guid senderId, Guid receiverId);
        Task<IEnumerable<TextMessage>> GetTextMessagesBySenderIdAsync(Guid senderId);
        Task<IEnumerable<TextMessage>> GetTextMessagesByReceiverIdAsync(Guid receiverId);
        Task<bool> DeleteTextMessageAsync(Guid textMessageId);
    }
}
