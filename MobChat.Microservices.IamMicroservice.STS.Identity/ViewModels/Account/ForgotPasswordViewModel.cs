using MobChat.Microservices.IamMicroservice.STS.Identity.Configuration;
using System.ComponentModel.DataAnnotations;
using MobChat.Microservices.IamMicroservice.Shared.Configuration.Identity;

namespace MobChat.Microservices.IamMicroservice.STS.Identity.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public LoginResolutionPolicy? Policy { get; set; }
        //[Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }
    }
}






