using Donation_Management.BusinessLayer.ViewModels;
using Donation_Management.DataLayer;
using Donation_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Management.BusinessLayer.Services.Repository
{
    public class DonationRepository : IDonationRepository
    {
        private readonly NgoDbContext _ngoContext;
        public DonationRepository(NgoDbContext ngoDbContext)
        {
            _ngoContext = ngoDbContext;
        }

        /// <summary>
        /// Return Donation by donation Id
        /// </summary>
        /// <param name="donationId"></param>
        /// <returns></returns>
        public async Task<Donation> FindDonationById(long donationId)
        {
            try
            {
                return await _ngoContext.Donation.FindAsync(donationId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="donation"></param>
        /// <returns></returns>
        public async Task<Donation> Register(Donation donation)
        {
            try
            {
                var result = await _ngoContext.Donation.AddAsync(donation);
                await _ngoContext.SaveChangesAsync();
                return donation;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Donation> UpdateDonation(RegisterDonationViewModel model)
        {
            var donation = await _ngoContext.Donation.FindAsync(model.DonationId);
            try
            {
                donation.Amount = model.Amount;
                donation.Type = model.Type;
                donation.DonorId = model.DonorId;
                donation.NgoId = model.NgoId;
                donation.Date = DateTime.Now;
                donation.IsDeleted = model.IsDeleted;

                _ngoContext.Donation.Update(donation);
                await _ngoContext.SaveChangesAsync();
                return donation;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Donation>> ListAllDonation()
        {
            try
            {
                var result = _ngoContext.Donation.
                OrderByDescending(x => x.DonationId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ngoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Donation>> GetDonationByNgoId(long ngoId)
        {
            try
            {
                var result =  _ngoContext.Donation.
                Where(x => x.NgoId == ngoId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="donorId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Donation>> GetDonationForDonor(long donorId)
        {
            try
            {
                var result = _ngoContext.Donation.
                Where(x => x.DonorId == donorId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
