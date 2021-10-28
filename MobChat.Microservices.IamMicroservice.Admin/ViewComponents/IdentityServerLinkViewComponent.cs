using Microsoft.AspNetCore.Mvc;
using MobChat.Microservices.IamMicroservice.Admin.Configuration.Interfaces;

namespace MobChat.Microservices.IamMicroservice.Admin.ViewComponents
{
    public class IdentityServerLinkViewComponent : ViewComponent
    {
        private readonly IRootConfiguration _configuration;

        public IdentityServerLinkViewComponent(IRootConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IViewComponentResult Invoke()
        {
            var identityServerUrl = _configuration.AdminConfiguration.IdentityServerBaseUrl;
            
            return View(model: identityServerUrl);
        }
    }
}






