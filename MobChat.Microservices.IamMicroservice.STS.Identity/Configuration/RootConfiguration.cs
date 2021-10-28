using MobChat.Microservices.IamMicroservice.Shared.Configuration.Identity;
using MobChat.Microservices.IamMicroservice.STS.Identity.Configuration.Interfaces;

namespace MobChat.Microservices.IamMicroservice.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}





