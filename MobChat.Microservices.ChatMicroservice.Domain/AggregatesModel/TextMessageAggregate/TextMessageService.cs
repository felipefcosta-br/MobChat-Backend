using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.TextMessageAggregate
{
    public class TextMessageService : ITextMessageService
    {
        private readonly ITextMessageRepository repository;

        public TextMessageService(ITextMessageRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddTextMessageAsync(TextMessage textMessage)
        {
            textMessage.Id = Guid.NewGuid();
            await repository.CreateAsync(textMessage);
            return await repository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTextMessageAsync(Guid textMessageId)
        {
            await repository.DeleteAsync(textMessageId);
            return await repository.SaveChangesAsync() > 0;
        }

        public async Task<TextMessage> GetTextMessageAsync(Guid textMessageId)
        {
            return await repository.ReadAsync(textMessageId);
        }

        public async Task<IEnumerable<TextMessage>> GetTextMessagesByChatIdAsync(Guid chatId)
        {
            return await repository.GetTextMessagesByChatId(chatId);
        }

        public async Task<IEnumerable<TextMessage>> GetTextMessagesByReceiverIdAsync(Guid receiverId)
        {
            return await repository.GetTextMessagesByReceiverIdAsync(receiverId);
        }

        public async Task<IEnumerable<TextMessage>> GetTextMessagesBySenderIdAndReceiverIdAsync(Guid senderId, Guid receiverId)
        {
            return await repository.GetTextMessagesBySenderIdAndReceiverIdAsync(senderId, receiverId);
        }

        public async Task<IEnumerable<TextMessage>> GetTextMessagesBySenderIdAsync(Guid senderId)
        {
            return await repository.GetTextMessagesBySenderIdAsync(senderId);
        }

        public async Task<IEnumerable<TextMessage>> GetTextMessagseBySenderIdOrReceiverIdAsync(Guid id)
        {
            return await repository.GetTextMessagesBySenderIdOrReceiverIdAsync(id);
        }
    }
}
