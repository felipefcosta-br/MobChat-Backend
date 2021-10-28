using MobChat.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobChat.Microservices.ProfileMicroservice.Domain.AggregatesModel.ProfileAggregate
{
    public class Profile : EntityBase<Guid>
    {
        public Guid AccountId { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String UserName { get; set; }
        public String Gender { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String Photo { get; set; }
        public String Thumbnail { get; set; }
        public String Email { get; set; }
        public String MobileNumber { get; set; }
        public Boolean isVisibleEmail { get; set; }
        public Boolean isVisiblePhone { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime Registration { get; set; }
    }
}
