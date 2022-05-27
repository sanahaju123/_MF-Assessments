using Donation_Management.BusinessLayer.ViewModels;
using Donation_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Management.BusinessLayer.Services.Repository
{
    public interface IDonationRepository
    {
        Task<Donation> Register(Donation donation);
        Task<Donation> FindDonationById(long donationId);
        Task<Donation> UpdateDonation(RegisterDonationViewModel model);
        Task<IEnumerable<Donation>> ListAllDonation();
        Task<IEnumerable<Donation>> GetDonationByNgoId(long ngoId);
        Task<IEnumerable<Donation>> GetDonationForDonor(long donorId);
    }
}
