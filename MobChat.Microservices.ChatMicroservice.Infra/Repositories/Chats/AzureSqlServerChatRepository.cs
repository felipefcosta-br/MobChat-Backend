using MobChat.Common.Infra.DataAccess.Repositories;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ChatAggregate;
using MobChat.Microservices.ChatMicroservice.Infra.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Infra.Repositories.Chats
{
    public class AzureSqlServerChatRepository : EntityFrameworkRepositoryBase<Guid, Chat>, IChatRepository
    {
        public AzureSqlServerChatRepository()
            : base(new ChatHubContext("Server=[AzureRepository];"))
        {

        }
        public Task<IEnumerable<Chat>> GetChatsByMemberId(Guid memberId)
        {
            var result = dbContext.Set<Chat>().Where(chat => chat.FirstMemberId == memberId || chat.SecondMemberId == memberId).AsEnumerable();
            return Task.FromResult(result);
        }


        public Task<IEnumerable<Chat>> GetChatsByMembersId(Guid firstMemberID, Guid secondMemberID)
        {
            var result = dbContext.Set<Chat>().Where(chat => (chat.FirstMemberId == firstMemberID && chat.SecondMemberId == secondMemberID)
            || (chat.FirstMemberId == secondMemberID && chat.SecondMemberId == firstMemberID)).AsEnumerable();

            return Task.FromResult(result);
        }
    }
}
