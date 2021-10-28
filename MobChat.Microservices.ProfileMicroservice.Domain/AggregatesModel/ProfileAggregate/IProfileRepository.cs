using MobChat.Common.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ProfileMicroservice.Domain.AggregatesModel.ProfileAggregate
{
    public interface IProfileRepository : IRepository<Guid, Profile>
    {
        Task<Profile> FindByAccountIdAsync(Guid accountId);
        Task<Profile> GetProfileByUserName(String userName);
        IEnumerable<Profile> SearchForProfiles(string searchTxt);
    }
}
