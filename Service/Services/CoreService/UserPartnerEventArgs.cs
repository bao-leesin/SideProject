using Microsoft.Extensions.Hosting;
using Service.DTOs;
using Service.Interfaces.CoreService;

namespace Service.Services.CoreService
{
    public class UserPartnerEventArgs : BackgroundService, IDisposable
    {
        private readonly IPartnerService _partnerService;
        private readonly IUserService _userService;

        public UserPartnerEventArgs(IPartnerService partnerService, IUserService userService)
        {
            partnerService = partnerService ?? throw new ArgumentNullException(nameof(partnerService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));

            // Subscribe to events

        }

        private void OnPartnerCreated(object? sender, PartnerEventArgs e)
        {
           UserCreateDto userCreateDto = new UserCreateDto
           {
               // Map properties from PartnerDto to UserCreateDto as needed
               Email = e.Partner.Email,
             
           };
            _userService.CreateUserAsync(userCreateDto).GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}