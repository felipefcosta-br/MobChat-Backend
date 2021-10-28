using Microsoft.EntityFrameworkCore;
using MobChat.Common.Infra.DataAccess.Repositories;
using MobChat.Microservices.ProfileMicroservice.Domain.AggregatesModel.ProfileAggregate;
using MobChat.Microservices.ProfileMicroservice.Infra.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobChat.Microservices.ProfileMicroservice.Infra.Repositories.Profiles
{
    public class AzureSqlServerProfilesRepository : EntityFrameworkRepositoryBase<Guid, Profile>, IProfileRepository
    {
        public AzureSqlServerProfilesRepository() : base(new ProfileContext("Server=[AzureRepository]"))
        {
        }

        public async Task<Profile> FindByAccountIdAsync(Guid accountId)
        {
            return await dbContext.Set<Profile>().FirstOrDefaultAsync(profile => profile.AccountId == accountId);
        }

        public async Task<Profile> GetProfileByUserName(string userName)
        {
            return await dbContext.Set<Profile>().FirstOrDefaultAsync(profile => profile.UserName == userName);
        }

        public IEnumerable<Profile> SearchForProfiles(string searchTxt)
        {
            var result = dbContext.Set<Profile>().Where(profile => profile.Name.ToLower().Contains(searchTxt.Trim().ToLower()) ||
                                                  profile.UserName.ToLower().Contains(searchTxt.Trim().ToLower())).AsEnumerable();
            return result;
        }
    }
}
