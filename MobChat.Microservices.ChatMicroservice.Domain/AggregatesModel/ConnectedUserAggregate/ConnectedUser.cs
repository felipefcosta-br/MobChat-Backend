using MobChat.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ConnectedUserAggregate
{
    public class ConnectedUser : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public String ContextUserId { get; set; }
        public String ConnectionId { get; set; }
    }
}
