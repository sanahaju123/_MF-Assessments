using Donation_Management.BusinessLayer.ViewModels;
using Donation_Management.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Management.BusinessLayer.Services.Repository
{
    public interface INgoRepository
    {
        Task<NgoDetails> Register(NgoDetails ngoDetails, string password);
        Task<NgoDetails> FindNgoById(long ngoId);
        Task<NgoDetails> UpdateNgo(RegisterNgoViewModel model);
        Task<IEnumerable<NgoDetails>> ListAllNgos();
    }
}
