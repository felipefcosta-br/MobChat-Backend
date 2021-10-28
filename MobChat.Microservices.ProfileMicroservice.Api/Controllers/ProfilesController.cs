using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobChat.Microservices.ProfileMicroservice.Domain.AggregatesModel.ProfileAggregate;
using MobChat.Microservices.ProfileMicroservice.Infra.DataAccess;

namespace MobChat.Microservices.ProfileMicroservice.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService profileService;

        public ProfilesController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        // GET: api/Profiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            return Ok(await profileService.GetAllProfilesAsync());
        }

        // GET: api/Profiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfile(Guid id)
        {
            var profile = await profileService.GetProfileAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        // GET: api/Profiles/account/5
        [HttpGet("account/{accountId}")]
        public async Task<ActionResult<Profile>> GetProfileByAccountId(Guid accountId)
        {
            var profile = await profileService.GetProfileByAccountIdAsync(accountId);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;

        }

        // GET: api/Profiles/UserName/Name
        [HttpGet("username/{username}")]
        public async Task<ActionResult<Profile>> GetProfileByUserName(String userName)
        {
            var profile = await profileService.GetProfileByUserNameAsync(userName);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        // GET: api/Profiles/Search/SearchTxt
        [HttpGet("search/{searchTxt}")]
        public ActionResult<IEnumerable<Profile>> SearchForUser(string searchTxt)
        {
            IEnumerable<Profile> result = profileService.SearchForProfile(searchTxt);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Profiles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(Guid id, Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            var result = await profileService.UpdateProfileAsync(profile);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // POST: api/Profiles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            var result = await profileService.AddProfileAsync(profile);

            if (!result)
                BadRequest("Profile invalid");

            return Created("api/profile", profile);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> DeleteProfile(Guid id)
        {
            var result = await profileService.DeleteProfileAsync(id);

            if (!result)
                return NotFound("Profile not found!");

            return Ok(id);
        }

    }
}
