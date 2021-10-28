using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ProfileMicroservice.Domain.AggregatesModel.ProfileAggregate
{
    public interface IProfileService
    {
        Task<bool> AddProfileAsync(Profile profile);
        Task<Profile> GetProfileAsync(Guid profileId);
        Task<Profile> GetProfileByAccountIdAsync(Guid accountId);
        Task<Profile> GetProfileByUserNameAsync(String userName);
        IEnumerable<Profile> GetAllProfiles();
        Task<IEnumerable<Profile>> GetAllProfilesAsync();
        IEnumerable<Profile> SearchForProfile(string searchTxt);        
        Task<bool> UpdateProfileAsync(Profile profile);
        Task<bool> DeleteProfileAsync(Guid profileId);
    }
}
