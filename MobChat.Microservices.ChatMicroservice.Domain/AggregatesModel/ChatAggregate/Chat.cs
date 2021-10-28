using MobChat.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobChat.Microservices.ChatMicroservice.Domain.AggregatesModel.ChatAggregate
{
    public class Chat : EntityBase<Guid>
    {
        public Guid FirstMemberId { get; set; }
        public String FirstMemberName { get; set; }
        public String FirstMemberPhoto { get; set; }
        public Guid SecondMemberId { get; set; }
        public String SecondMemberName { get; set; }
        public String SecondMemberPhoto { get; set; }
        public DateTime FirstMessageDate { get; set;  }
        public DateTime LastMessageDate { get; set; }
        public String Status { get; set; }
        public Boolean IsOnline { get; set; }
    }
}
