using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ProfileMicroservice.Domain.AggregatesModel.ProfileAggregate
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository repository;

        public ProfileService(IProfileRepository repository)
        {
            this.repository = repository;
        }
        public async Task<bool> AddProfileAsync(Profile profile)
        {
            profile.Id = Guid.NewGuid();
            await repository.CreateAsync(profile);
            return await repository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProfileAsync(Guid profileId)
        {
            await repository.DeleteAsync(profileId);
            return await repository.SaveChangesAsync() > 0;
        }

        public IEnumerable<Profile> GetAllProfiles()
        {
            return repository.ReadAll();
        }

        public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
        {
            return await repository.ReadAllAsync();
        }

        public async Task<Profile> GetProfileAsync(Guid profileId)
        {
            return await repository.ReadAsync(profileId);
        }

        public async Task<Profile> GetProfileByAccountIdAsync(Guid accountId)
        {
            return await repository.FindByAccountIdAsync(accountId);
        }

        public async Task<Profile> GetProfileByUserNameAsync(string userName)
        {
            return await repository.GetProfileByUserName(userName);
        }

        public IEnumerable<Profile> SearchForProfile(string searchTxt)
        {
            return repository.SearchForProfiles(searchTxt);
        }

        public async Task<bool> UpdateProfileAsync(Profile profile)
        {
            repository.Update(profile);
            return await repository.SaveChangesAsync() > 0;
        }
    }
}
