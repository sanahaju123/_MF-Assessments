using Donation_Management.BusinessLayer.ViewModels;
using Donation_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Management.BusinessLayer.Interfaces
{
    public interface IDonorServices
    {
        Task<Donor> Register(Donor donor, string password);
        Task<Donor> FindDonorById(long donorId);
        Task<Donor> UpdateDonor(RegisterDonorViewModel model);
        Task<IEnumerable<Donor>> ListAllDonors();
        Task<IEnumerable<Donor>> GetDonorByNgoId(long ngoId);
    }
}
