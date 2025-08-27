using Service.DTOs;

namespace Service.Services.CoreService
{
    public class UserEventArgs : EventArgs
    {
        public UserDto User { get; }
        public UserEventArgs(UserDto user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}