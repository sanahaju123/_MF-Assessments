using Donation_Management.BusinessLayer.Interfaces;
using Donation_Management.BusinessLayer.ViewModels;
using Donation_Management.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace Donation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NgoController : ControllerBase
    {
        private readonly INgoServices _ngoServices;
        private readonly IDonationRequestServices _donationRequestServices;
        public NgoController(INgoServices ngoServices, IDonationRequestServices donationRequestServices)
        {
            _ngoServices = ngoServices;
            _donationRequestServices = donationRequestServices;
        }

        #region NgoRegion
        /// <summary>
        /// Register a new NGO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ngos/register-ngo")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterNgoViewModel model)
        {
            var ngoExists = await _ngoServices.FindNgoById(model.NgoId);
            if (ngoExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            //New object and value for user
            NgoDetails ngoDetails = new NgoDetails()
            {

                Name = model.Name,
                Username = model.Name,
                Password = model.Password,
                Address = model.Address,
                Phone = model.Phone,
                StartedIn = model.StartedIn,
                FilePath = model.FilePath,
                IsDeleted = false
            };
            var result = await _ngoServices.Register(ngoDetails, model.Password);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ngo creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "Ngo created successfully!" });

        }

        /// <summary>
        /// Update a existing NGO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ngos/update-ngo")]
        public async Task<IActionResult> UpdateNgo([FromBody] RegisterNgoViewModel model)
        {
            var ngo = await _ngoServices.FindNgoById(model.NgoId);
            if (ngo == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Ngo With Id = {model.NgoId} cannot be found" });
            }
            else
            {
                var result = await _ngoServices.UpdateNgo(model);
                return Ok(new Response { Status = "Success", Message = "Ngo Edited successfully!" });
            }
        }


        /// <summary>
        /// Delete a existing NGO
        /// </summary>
        /// <param name="NgoId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("ngos/delete-ngo/{NgoId}")]
        public async Task<IActionResult> DeletNgo(long NgoId)
        {
            var ngo = await _ngoServices.FindNgoById(NgoId);
            if (ngo == null || ngo.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Ngo With Id = {NgoId} cannot be found" });
            }
            else
            {
                RegisterNgoViewModel register = new RegisterNgoViewModel();
                register.NgoId = ngo.NgoId;
                register.Name = ngo.Name;
                register.Username = ngo.Username;
                register.StartedIn = ngo.StartedIn;
                register.Phone = ngo.Phone;
                register.Password = ngo.Password;
                register.IsDeleted = true;
                var result = await _ngoServices.UpdateNgo(register);
                return Ok(new Response { Status = "Success", Message = "Ngo deleted successfully!" });
            }
        }

        /// <summary>
        /// Get NGO by Id
        /// </summary>
        /// <param name="NgoId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ngos/get/{NgoId}")]
        public async Task<IActionResult> GetNgoById(long NgoId)
        {
            var ngo = await _ngoServices.FindNgoById(NgoId);
            if (ngo == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Ngo With Id = {NgoId} cannot be found" });
            }
            else
            {
                return Ok(ngo);
            }
        }

        /// <summary>
        /// List All Ngos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ngos/all")]
        public async Task<IEnumerable<NgoDetails>> ListAllNgos()
        {
            return await _ngoServices.ListAllNgos();
        }
        #endregion


        #region DonationRequestRegion
        /// <summary>
        /// Create a new Donation Request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ngos/create-donation-request")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] RegisterDonationRequestViewModel model)
        {
            var donationRequestExists = await _donationRequestServices.FindDonationRequestById(model.DonationRequestId);
            if (donationRequestExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Donation Request already exists!" });
            //New object and value for user
            DonationRequest donationRequest = new DonationRequest()
            {

                Amount = model.Amount,
                EndDate = model.EndDate,
                DonationId = model.DonationId,
                DonorId = model.DonorId,
                NgoId = model.NgoId,
                IsDeleted = false
            };
            var result = await _donationRequestServices.Register(donationRequest);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Donation Request creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "Donation Request created successfully!" });

        }

        /// <summary>
        /// Get Donation Request by Ngo Id
        /// </summary>
        /// <param name="NgoId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ngos/donation-request-by-ngo/{NgoId}")]
        public async Task<IActionResult> GetDonationRequestByNgoId(long NgoId)
        {
            var donationRequest = await _donationRequestServices.GetDonationRequestByNgoId(NgoId);
            if (donationRequest == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Donation Request With NgoId = {NgoId} cannot be found" });
            }
            else
            {
                return Ok(donationRequest);
            }
        }

        /// <summary>
        /// Get Donation Request By Donor Id
        /// </summary>
        /// <param name="donorId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ngos/donation-request-by-donor/{donorId}")] 
        public async Task<IEnumerable<DonationRequest>> GetDonationRequestForDonorId(long donorId)
        {
            return await _donationRequestServices.GetDonationRequestForDonor(donorId);
        }
        #endregion
    }
}