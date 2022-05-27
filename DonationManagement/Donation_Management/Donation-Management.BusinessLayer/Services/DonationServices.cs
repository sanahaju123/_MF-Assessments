using Donation_Management.BusinessLayer.Interfaces;
using Donation_Management.BusinessLayer.Services.Repository;
using Donation_Management.BusinessLayer.ViewModels;
using Donation_Management.DataLayer;
using Donation_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Management.BusinessLayer.Services
{
    public class DonationServices:IDonationServices
    {
        private readonly IDonationRepository _donationRepository;
        private readonly NgoDbContext _ngoContext;

        public DonationServices(IDonationRepository donationRepository, NgoDbContext ngoDbContext)
        {
            _donationRepository = donationRepository;
            _ngoContext = ngoDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="donationId"></param>
        /// <returns></returns>
        public async Task<Donation> FindDonationById(long donationId)
        {
            return await _donationRepository.FindDonationById(donationId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="donationDetails"></param>
        /// <returns></returns>
        public async Task<Donation> Register(Donation donationDetails)
        {
            return await _donationRepository.Register(donationDetails);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Donation> UpdateDonation(RegisterDonationViewModel model)
        {
            return await _donationRepository.UpdateDonation(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Donation>> ListAllDonation()
        {
            return await _donationRepository.ListAllDonation();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ngoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Donation>> GetDonationByNgoId(long ngoId)
        {
            return await _donationRepository.GetDonationByNgoId(ngoId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="donorId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Donation>> GetDonationForDonor(long donorId)
        {
            return await _donationRepository.GetDonationForDonor(donorId);
        }
    }
}


