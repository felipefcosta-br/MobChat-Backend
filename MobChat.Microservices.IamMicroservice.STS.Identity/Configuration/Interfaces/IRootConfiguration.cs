using MobChat.Microservices.IamMicroservice.Shared.Configuration.Identity;

namespace MobChat.Microservices.IamMicroservice.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}





