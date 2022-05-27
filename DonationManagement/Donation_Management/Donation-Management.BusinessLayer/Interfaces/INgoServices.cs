using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donation_Management.Entities;
using Donation_Management.BusinessLayer.ViewModels;

namespace Donation_Management.BusinessLayer.Interfaces
{
    public interface INgoServices
    {
        Task<NgoDetails> Register(NgoDetails ngoDetails, string password);
        Task<NgoDetails> FindNgoById(long ngoId);
        Task<NgoDetails> UpdateNgo(RegisterNgoViewModel model);
        Task<IEnumerable<NgoDetails>> ListAllNgos();

    }
}
