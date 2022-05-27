using Donation_Management.BusinessLayer.Interfaces;
using Donation_Management.BusinessLayer.Services.Repository;
using Donation_Management.BusinessLayer.ViewModels;
using Donation_Management.DataLayer;
using Donation_Management.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Management.BusinessLayer.Services
{
    public class NgoServices:INgoServices
    {
        private readonly INgoRepository _ngoRepository;
        private readonly NgoDbContext _ngoContext;

        public NgoServices(INgoRepository ngoRepository,NgoDbContext ngoDbContext)
        {
            _ngoRepository = ngoRepository;
            _ngoContext = ngoDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ngoId"></param>
        /// <returns></returns>
        public async Task<NgoDetails> FindNgoById(long ngoId)
        {
            return await _ngoRepository.FindNgoById(ngoId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ngoDetails"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<NgoDetails> Register(NgoDetails ngoDetails, string password)
        {
            return await _ngoRepository.Register(ngoDetails, password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<NgoDetails> UpdateNgo(RegisterNgoViewModel model)
        {
            return await _ngoRepository.UpdateNgo(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<NgoDetails>> ListAllNgos()
        {
            return await _ngoRepository.ListAllNgos();
        }
        
    }
}
