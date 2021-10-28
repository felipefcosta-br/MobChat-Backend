using MobChat.Common.Infra.DataAccess.Repositories;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.TextMessageAggregate;
using MobChat.Microservices.ChatMicroservice.Infra.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Infra.Repositories.TextMessages
{
    public class AzureSqlServerTextMessageRepository : EntityFrameworkRepositoryBase<Guid, TextMessage>, ITextMessageRepository
    {
        public AzureSqlServerTextMessageRepository()
            : base(new ChatHubContext("Server=[AzureRepository];"))
        {

        }
        public Task<IEnumerable<TextMessage>> GetTextMessagesByChatId(Guid chatId)
        {
            var result = dbContext.Set<TextMessage>().Where(message => message.ChatId == chatId).AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<IEnumerable<TextMessage>> GetTextMessagesByReceiverIdAsync(Guid receiverId)
        {
            var result = dbContext.Set<TextMessage>().Where(message => message.ReceiverId == receiverId).AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<IEnumerable<TextMessage>> GetTextMessagesBySenderIdAndReceiverIdAsync(Guid senderId, Guid receiverId)
        {
            var result = dbContext.Set<TextMessage>().Where(message =>message.SenderId == senderId && message.ReceiverId == receiverId).AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<IEnumerable<TextMessage>> GetTextMessagesBySenderIdAsync(Guid senderId)
        {
            var result = dbContext.Set<TextMessage>().Where(message => message.SenderId == senderId).AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<IEnumerable<TextMessage>> GetTextMessagesBySenderIdOrReceiverIdAsync(Guid id)
        {
            var result = dbContext.Set<TextMessage>().Where(message => message.SenderId == id || message.ReceiverId == id).AsEnumerable();
            return Task.FromResult(result);
        }
    }
}
