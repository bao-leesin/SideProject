using Service.DTOs;

namespace Service.Services.CoreService
{
    public class PartnerEventArgs : EventArgs
    {
        public PartnerDto Partner { get; }
        public PartnerEventArgs(PartnerDto partner)
        {
            Partner = partner ?? throw new ArgumentNullException(nameof(partner));
        }


    }
}