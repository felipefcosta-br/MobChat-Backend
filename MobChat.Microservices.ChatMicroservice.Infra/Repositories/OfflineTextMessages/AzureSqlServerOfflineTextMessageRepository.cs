using MobChat.Common.Infra.DataAccess.Repositories;
using MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.OfflineTextMessageAggregate;
using MobChat.Microservices.ChatMicroservice.Infra.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ChatMicroservice.Infra.Repositories.OfflineTextMessages
{
    public class AzureSqlServerOfflineTextMessageRepository :
        EntityFrameworkRepositoryBase<Guid, OfflineTextMessage>, IOfflineTextMessageRepository
    {
        public AzureSqlServerOfflineTextMessageRepository()
            : base(new ChatHubContext("Server=[AzureRepository];"))
        {

        }
        public async Task DeleteUserOfflineTextMessages(Guid receiverId, Guid senderId)
        {
            IEnumerable<OfflineTextMessage> offTextMessages = dbContext.Set<OfflineTextMessage>().
                Where(message => message.ReceiverId == receiverId && message.SenderId == senderId).AsEnumerable();

            foreach (OfflineTextMessage message in offTextMessages)
            {
                dbContext.Set<OfflineTextMessage>().Remove(await ReadAsync(message.Id));
            }
        }

        public IEnumerable<OfflineTextMessage> GetOfflineTextMessages(Guid receiverId)
        {
            var result = dbContext.Set<OfflineTextMessage>().Where(message => message.ReceiverId == receiverId).AsEnumerable();
            return result;
        }
    }
}
