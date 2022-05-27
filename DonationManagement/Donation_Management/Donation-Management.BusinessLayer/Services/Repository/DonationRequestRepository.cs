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
    public class DonationRequestRepository : IDonationRequestRepository
    {
        private readonly NgoDbContext _ngoContext;
        public DonationRequestRepository(NgoDbContext ngoDbContext)
        {
            _ngoContext = ngoDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="donationId"></param>
        /// <returns></returns>
        public async Task<DonationRequest> FindDonationRequestById(long donationId)
        {
            try
            {
                return await _ngoContext.DonationRequests.FindAsync(donationId);
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
        public async Task<DonationRequest> Register(DonationRequest donation)
        {
            try
            {
                var result = await _ngoContext.DonationRequests.AddAsync(donation);
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
        public async Task<DonationRequest> UpdateDonationRequest(RegisterDonationRequestViewModel model)
        {
            var donationRequest = await _ngoContext.DonationRequests.FindAsync(model.DonationRequestId);
            try
            {
                donationRequest.Amount = model.Amount;
                donationRequest.DonationId = model.DonationId;
                donationRequest.DonorId = model.DonorId;
                donationRequest.EndDate = model.EndDate;
                donationRequest.NgoId = model.NgoId;
                donationRequest.IsDeleted = model.IsDeleted;
                
                _ngoContext.DonationRequests.Update(donationRequest);
                await _ngoContext.SaveChangesAsync();
                return donationRequest;
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
        public async Task<IEnumerable<DonationRequest>> ListAllDonationRequest()
        {
            try
            {
                var result = _ngoContext.DonationRequests.
                OrderByDescending(x => x.DonationRequestId).Take(10).ToList();
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
        public async Task<IEnumerable<DonationRequest>> GetDonationRequestByNgoId(long ngoId)
        {
            try
            {
                var result = _ngoContext.DonationRequests.
                Where(x=>x.NgoId==ngoId).ToList();
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
        public async Task<IEnumerable<DonationRequest>> GetDonationRequestForDonor(long donorId)
        {
            try
            {
                var result = _ngoContext.DonationRequests.
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
