using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ChatAggregate
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository repository;

        public ChatService(IChatRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Guid> AddChatAsync(Chat chat)
        {
            chat.Id = Guid.NewGuid();
            await repository.CreateAsync(chat);
            if (await repository.SaveChangesAsync() > 0)
            {
                return chat.Id;
            }
            else
            {
                return Guid.Empty;
            }
            
        }

        public async Task<bool> DeleteChatAsync(Guid chatId)
        {
            await repository.DeleteAsync(chatId);
            return await repository.SaveChangesAsync() > 0;
        }

        public async Task<Chat> GetChatAsync(Guid chatId)
        {
            return await repository.ReadAsync(chatId);
        }

        public async Task<IEnumerable<Chat>> GetChatsByMemberId(Guid memberId)
        {
            return await repository.GetChatsByMemberId(memberId);
        }

        public async Task<IEnumerable<Chat>> GetChatsByMembersId(Guid firstMemberID, Guid secondMemberID)
        {
            return await repository.GetChatsByMembersId(firstMemberID, secondMemberID);
        }

        public async Task<bool> UpdateChatAsync(Chat chat)
        {
            repository.Update(chat);
            return await repository.SaveChangesAsync() > 0;
        }
    }
}
