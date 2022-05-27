using Donation_Management.BusinessLayer.Interfaces;
using Donation_Management.BusinessLayer.ViewModels;
using Donation_Management.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorServices _donorServices;
        private readonly IDonationServices _donationServices;
        public DonorController(IDonorServices donorServices, IDonationServices donationServices)
        {
            _donorServices = donorServices;
            _donationServices = donationServices;
        }

        #region DonorRegion
        /// <summary>
        /// Register a new Donor 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("donors/register-donors")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterDonorViewModel model)
        {
            var donorExists = await _donorServices.FindDonorById(model.DonorId);
            if (donorExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Donor already exists!" });
            //New object and value for user
            Donor donor = new Donor()
            {

                Name = model.Name,
                Username = model.Name,
                Password = model.Password,
                Address = model.Address,
                Phone = model.Phone,
                Email=model.Email,
                NgoId=model.NgoId,
                IsDeleted = false
            };
            var result = await _donorServices.Register(donor, model.Password);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Donor creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "Donor created successfully!" });

        }

        /// <summary>
        /// Update a existing Donor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("donors/update-donor")]
        public async Task<IActionResult> UpdateDonor([FromBody] RegisterDonorViewModel model)
        {
            var donor = await _donorServices.FindDonorById(model.DonorId);
            if (donor == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Donor With Id = {model.DonorId} cannot be found" });
            }
            else
            {
                var result = await _donorServices.UpdateDonor(model);
                return Ok(new Response { Status = "Success", Message = "Donor Edited successfully!" });
            }
        }

        /// <summary>
        /// Delete a existing Donor
        /// </summary>
        /// <param name="DonorId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("donors/delete-donor/{DonorId}")]
        public async Task<IActionResult> DeletDonor(long DonorId)
        {
            var donor = await _donorServices.FindDonorById(DonorId);
            if (donor == null || donor.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Donor With Id = {DonorId} cannot be found" });
            }
            else
            {
                RegisterDonorViewModel register = new RegisterDonorViewModel();
                register.DonorId = donor.DonorId;
                register.NgoId = donor.NgoId;
                register.Name = donor.Name;
                register.Username = donor.Username;
                register.Email = donor.Email;
                register.Address = donor.Address;
                register.Phone = donor.Phone;
                register.Password = donor.Password;
                register.IsDeleted = true;
                var result = await _donorServices.UpdateDonor(register);
                return Ok(new Response { Status = "Success", Message = "Donor deleted successfully!" });
            }
        }

        /// <summary>
        /// Get Donor by Id
        /// </summary>
        /// <param name="DonorId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("donors/get/{DonorId}")]
        public async Task<IActionResult> GetDonorById(long DonorId)
        {
            var donor = await _donorServices.FindDonorById(DonorId);
            if (donor == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Donor With Id = {DonorId} cannot be found" });
            }
            else
            {
                return Ok(donor);
            }
        }

        /// <summary>
        /// Get List of all Donors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("donors/all")]
        public async Task<IEnumerable<Donor>> ListAllDonors()
        {
            return await _donorServices.ListAllDonors();
        }


        /// <summary>
        /// Get All Donors by NGO Id
        /// </summary>
        /// <param name="ngoId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("donors/get-by-ngo/{ngoId}")]
        public async Task<IEnumerable<Donor>> ListDonorsByNgoId(long ngoId)
        {
            return await _donorServices.GetDonorByNgoId(ngoId);
        }
        #endregion

        #region DonationRegion

        /// <summary>
        /// Register a new Donation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("donation/create-donation")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] RegisterDonationViewModel model)
        {
            var donorExists = await _donationServices.FindDonationById(model.DonationId);
            if (donorExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Donation already exists!" });
            //New object and value for user
            Donation donation = new Donation()
            {

                Type = model.Type,
                Amount = model.Amount,
                Date = model.Date,
                DonorId = model.DonorId,
                NgoId = model.NgoId,
                IsDeleted = false
            };
            var result = await _donationServices.Register(donation);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Donation creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "Donation created successfully!" });

        }

        /// <summary>
        /// Update a Existing Donation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("donation/update-donation")]
        public async Task<IActionResult> UpdateDonation([FromBody] RegisterDonationViewModel model)
        {
            var donation = await _donationServices.FindDonationById(model.DonationId);
            if (donation == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Donation With Id = {model.DonationId} cannot be found" });
            }
            else
            {
                var result = await _donationServices.UpdateDonation(model);
                return Ok(new Response { Status = "Success", Message = "Donation Edited successfully!" });
            }
        }

        /// <summary>
        /// Delete a existing donation
        /// </summary>
        /// <param name="DonationId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("donation/delete-donation/{DonationId}")]
        public async Task<IActionResult> DeletDonation(long DonationId)
        {
            var donation = await _donationServices.FindDonationById(DonationId);
            if (donation == null || donation.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Donation With Id = {DonationId} cannot be found" });
            }
            else
            {
                RegisterDonationViewModel register = new RegisterDonationViewModel();
                register.DonationId = donation.DonationId;
                register.DonorId = donation.DonorId;
                register.NgoId = donation.NgoId;
                register.Type = donation.Type;
                register.Date = donation.Date;
                register.Amount = donation.Amount;
                register.IsDeleted = true;
                var result = await _donationServices.UpdateDonation(register);
                return Ok(new Response { Status = "Success", Message = "Donation deleted successfully!" });
            }
        }
        
        /// <summary>
        /// Get donation by Id
        /// </summary>
        /// <param name="DonationId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("donation/get/{DonationId}")]
        public async Task<IActionResult> GetDonationById(long DonationId)
        {
            var donation = await _donationServices.FindDonationById(DonationId);
            if (donation == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Donation With Id = {DonationId} cannot be found" });
            }
            else
            {
                return Ok(donation);
            }
        }
        

        /// <summary>
        /// List All Donations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("donation/all")]
        public async Task<IEnumerable<Donation>> ListAllDonations()
        {
            return await _donationServices.ListAllDonation();
        }


        /// <summary>
        /// Get donor by donor Id
        /// </summary>
        /// <param name="donorId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("donation/get-by-donor/{donorId}")]
        public async Task<IEnumerable<Donation>> GetDonationByDonorId(long donorId)
        {
            return await _donationServices.GetDonationForDonor(donorId);
        }


        /// <summary>
        /// Get donation by Ngo Id
        /// </summary>
        /// <param name="ngoId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("donation/get-by-ngo/{ngoId}")]
        public async Task<IEnumerable<Donation>> GetDonationByNgoId(long ngoId)
        {
            return await _donationServices.GetDonationByNgoId(ngoId);
        }
        #endregion
    }
}

