using MobChat.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.TextMessageAggregate
{
    public class TextMessage: EntityBase<Guid>
    {
        public Guid ChatId { get; set; }
        public Guid SenderId { get; set; }
        public String SenderName { get; set; }
        public String SenderPhoto { get; set; }
        public Guid ReceiverId { get; set; }
        public String ReceiverName { get; set; }
        public String ReceiverPhoto { get; set; }
        public DateTime MessageDate { get; set; }
        public String Message { get; set; }
        public String Status { get; set; }
    }
}
