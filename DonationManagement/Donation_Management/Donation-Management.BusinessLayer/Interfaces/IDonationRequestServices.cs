using Donation_Management.BusinessLayer.ViewModels;
using Donation_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Management.BusinessLayer.Interfaces
{
    public interface IDonationRequestServices
    {
        Task<DonationRequest> Register(DonationRequest donationRequest);
        Task<DonationRequest> FindDonationRequestById(long donationRequestId);
        Task<DonationRequest> UpdateDonationRequest(RegisterDonationRequestViewModel model);
        Task<IEnumerable<DonationRequest>> ListAllDonationRequest();
        Task<IEnumerable<DonationRequest>> GetDonationRequestByNgoId(long ngoId);
        Task<IEnumerable<DonationRequest>> GetDonationRequestForDonor(long donorId);
    }
}

