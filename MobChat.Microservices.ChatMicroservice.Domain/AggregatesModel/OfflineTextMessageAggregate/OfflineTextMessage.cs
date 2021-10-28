﻿using MobChat.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.OfflineTextMessageAggregate
{
    public class OfflineTextMessage : EntityBase<Guid>
    {
        public Guid ReceiverId { get; set; }
        public Guid SenderId { get; set; }
        public String Message { get; set; }
    }
}
