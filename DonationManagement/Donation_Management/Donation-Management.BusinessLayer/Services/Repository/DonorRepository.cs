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
    public class DonorRepository:IDonorRepository
    {
        private readonly NgoDbContext _ngoContext;
        public DonorRepository(NgoDbContext ngoDbContext)
        {
            _ngoContext = ngoDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="donorId"></param>
        /// <returns></returns>
        public async Task<Donor> FindDonorById(long donorId)
        {
            try
            {
                return await _ngoContext.Donors.FindAsync(donorId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="donor"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Donor> Register(Donor donor, string password)
        {
            try
            {
                Donor donor1 = new Donor();
                donor1.Password = password;
                donor.Password = donor1.Password;

                var result = await _ngoContext.Donors.AddAsync(donor);
                await _ngoContext.SaveChangesAsync();
                return donor;
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
        public async Task<Donor> UpdateDonor(RegisterDonorViewModel model)
        {
            var donor = await _ngoContext.Donors.FindAsync(model.DonorId);
            try
            {
                donor.Name = model.Name;
                donor.Username = model.Username;
                donor.Email = model.Email;
                donor.Password = model.Password;
                donor.Phone = model.Phone;
                donor.Address = model.Address;
                donor.NgoId = model.NgoId;
                donor.IsDeleted = model.IsDeleted;

                _ngoContext.Donors.Update(donor);
                await _ngoContext.SaveChangesAsync();
                return donor;
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
        public async Task<IEnumerable<Donor>> ListAllDonors()
        {
            try
            {
                var result = _ngoContext.Donors.
                OrderByDescending(x => x.DonorId).Take(10).ToList();
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
        public async Task<IEnumerable<Donor>> GetDonorByNgoId(long ngoId)
        {
            try
            {
                var result = _ngoContext.Donors.
                Where(x => x.NgoId == ngoId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
    
