using Donation_Management.BusinessLayer.Interfaces;
using Donation_Management.BusinessLayer.Services;
using Donation_Management.BusinessLayer.Services.Repository;
using Donation_Management.BusinessLayer;
using Donation_Management.Entities;
using Donation_Management.TestCases;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Donation_Management.BusinessLayer.ViewModels;
using Donation_Management.DataLayer;

namespace Donation_Management.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly NgoDbContext _ngoContext;

        private readonly INgoServices _ngoServices;
        private readonly IDonorServices _donorServices;
        private readonly IDonationServices _donationServices;
        private readonly IDonationRequestServices _donationRequestServices;

        public readonly Mock<INgoRepository> ngoservice = new Mock<INgoRepository>();
        public readonly Mock<IDonorRepository> donorservice = new Mock<IDonorRepository>();
        public readonly Mock<IDonationRepository> donationservice = new Mock<IDonationRepository>();
        public readonly Mock<IDonationRequestRepository> donationRequestservice = new Mock<IDonationRequestRepository>();

        private readonly NgoDetails _ngoDetails;
        private readonly Donor _donor;
        private readonly Donation _donation;
        private readonly DonationRequest _donationRequest;

        private readonly RegisterNgoViewModel _registerNgoViewModel;
        private readonly RegisterDonorViewModel _registerDonorViewModel;
        private readonly RegisterDonationViewModel _registerDonationViewModel;
        private readonly RegisterDonationRequestViewModel _registerDonationRequestViewModel;
        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _ngoServices = new NgoServices(ngoservice.Object,_ngoContext);
            _donorServices = new DonorServices(donorservice.Object, _ngoContext);
            _donationServices = new DonationServices(donationservice.Object, _ngoContext);
            _donationRequestServices = new DonationRequestServices(donationRequestservice.Object, _ngoContext);
            _output = output;

            _ngoDetails = new NgoDetails
            {
                //NgoId = 8,
                Name = "Ngo1",
                Username = "Ngo_UN",
                Password = "Pass123",
                Address = "Mumbai,Maharastra",
                Phone = "9632584754",
                StartedIn = DateTime.Now,
                FilePath = "file.txt",
                IsDeleted=false
            };
            _donor = new Donor
            {
                DonorId = 8,
                Name = "Donor1",
                Username = "Donor_UN",
                Password = "Pass123",
                Email = "Donor1@gmail.com",
                Address = "Pune,Maharashtra",
                Phone = "9435231423",
                IsDeleted = false,
                NgoId = 1
            };
            _donation = new Donation
            {
                DonationId = 8,
                Type = "DonationType1",
                Amount = 1000,
                Date = DateTime.Now,
                IsDeleted = false,
                NgoId = 1,
                DonorId = 1,

            };
            _donationRequest = new DonationRequest
            {
                 DonationRequestId=8,
                 Amount=2000,
                 Status="Done",
                 EndDate=DateTime.Now,
                 IsDeleted=false,
                 NgoId=1,
                 DonorId=1,
                 DonationId=1
            };
            _registerNgoViewModel = new RegisterNgoViewModel
            {
                NgoId = 8,
                Name = "Ngo1",
                Username = "Ngo_UN",
                Password = "Pass123",
                Address = "Mumbai,Maharastra",
                Phone = "9632584754",
                StartedIn = DateTime.Now,
                FilePath = "file.txt",
                IsDeleted = false
            };
            _registerDonorViewModel = new RegisterDonorViewModel
            {
                DonorId = 8,
                Name = "Donor1",
                Username = "Donor_UN",
                Password = "Pass123",
                Email = "Donor1@gmail.com",
                Address = "Pune,Maharashtra",
                Phone = "9435231423",
                IsDeleted = false,
                NgoId = 1
            };
            _registerDonationViewModel = new RegisterDonationViewModel
            {
                DonationId = 8,
                Type = "DonationType1",
                Amount = 1000,
                Date = DateTime.Now,
                IsDeleted = false,
                NgoId = 1,
                DonorId = 1,
            };
            _registerDonationRequestViewModel = new RegisterDonationRequestViewModel
            {
                DonationRequestId = 8,
                Amount = 2000,
                Status = "Done",
                EndDate = DateTime.Now,
                IsDeleted = false,
                NgoId = 1,
                DonorId = 1,
                DonationId = 1
            };
        }
        #region RegionNgo
        /// <summary>
        /// Test to register new Ngo for Donation Management Application
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Register_Ngo()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                ngoservice.Setup(repos => repos.Register(_ngoDetails, _ngoDetails.Password)).ReturnsAsync(_ngoDetails);
                var result = await _ngoServices.Register(_ngoDetails, _ngoDetails.Password);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Using the below test method Update Ngo by using Ngo Id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_Ngo()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateNgo = new RegisterNgoViewModel()
            {
                NgoId = 5,
                Name = "Ngo11",
                Username = "Ngo_UN",
                Password = "Pass123",
                Address = "Mumbai,Maharastra",
                Phone = "9632584754",
                StartedIn = DateTime.Now,
                FilePath = "file.txt",
                IsDeleted=false,
            };
            //Act
            try
            {
                ngoservice.Setup(repos => repos.UpdateNgo(_updateNgo)).ReturnsAsync(_ngoDetails); ;
                var result = await _ngoServices.UpdateNgo(_updateNgo);
                if (result !=null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Test to list all Ngos 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Ngos()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                ngoservice.Setup(repos => repos.ListAllNgos());
                var result = await _ngoServices.ListAllNgos();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to find Ngo by Ngo Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindNgoById()
        {
            //Arrange
            var res = false;
            int ngoId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                ngoservice.Setup(repos => repos.FindNgoById(ngoId)).ReturnsAsync(_ngoDetails); ;
                var result = await _ngoServices.FindNgoById(ngoId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
        #endregion 

        #region RegionDonor
        [Fact]
        public async Task<bool> Testfor_Register_Donor()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                donorservice.Setup(repos => repos.Register(_donor, _donor.Password)).ReturnsAsync(_donor); ;
                var result = await _donorServices.Register(_donor, _donor.Password);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Update_Donor()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateDonor = new RegisterDonorViewModel()
            {
                DonorId = 1,
                Name = "Donor1",
                Username = "Donor_UN",
                Password = "Pass123",
                Email = "Donor1@gmail.com",
                Address = "Pune,Maharashtra",
                Phone = "9435231423",
                IsDeleted = false,
                NgoId = 1
            };
            //Act
            try
            {
                donorservice.Setup(repos => repos.UpdateDonor(_updateDonor)).ReturnsAsync(_donor);
                var result = await _donorServices.UpdateDonor(_updateDonor);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_ListAll_Donors()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                donorservice.Setup(repos => repos.ListAllDonors());
                var result = await _donorServices.ListAllDonors();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_FindDonorById()
        {
            //Arrange
            var res = false;
            int donorId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                donorservice.Setup(repos => repos.FindDonorById(donorId)).ReturnsAsync(_donor);
                var result = await _donorServices.FindDonorById(donorId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
        #endregion 

        #region RegionDonation
        /// <summary>
        /// Test to create Donation
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Create_Donation()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                donationservice.Setup(repos => repos.Register(_donation)).ReturnsAsync(_donation);
                var result = await _donationServices.Register(_donation);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to Edit Donation By Donation Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_Donation()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateDonation = new RegisterDonationViewModel()
            {
                DonationId = 1,
                Type = "DonationType1",
                Amount = 1000,
                Date = DateTime.Now,
                IsDeleted = false,
                NgoId = 1,
                DonorId = 1
            };
            //Act
            try
            {
                donationservice.Setup(repos => repos.UpdateDonation(_updateDonation)).ReturnsAsync(_donation);
                var result = await _donationServices.UpdateDonation(_updateDonation);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to list all donations
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Donations()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                donationservice.Setup(repos => repos.ListAllDonation());
                var result = await _donationServices.ListAllDonation();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to find donation By donation Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindDonationById()
        {
            //Arrange
            var res = false;
            int donationId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                donationservice.Setup(repos => repos.FindDonationById(donationId)).ReturnsAsync(_donation);
                var result = await _donationServices.FindDonationById(donationId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
        #endregion 

        #region RegionDonationRequest

        /// <summary>
        /// Test to Create donation Request
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Create_DonationRequest()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                donationRequestservice.Setup(repos => repos.Register(_donationRequest)).ReturnsAsync(_donationRequest);
                var result = await _donationRequestServices.Register(_donationRequest);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to List all donation Request By NgoId
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAllDonations_ByNgoId()
        {
            //Arrange
            var res = false;
            int ngoId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                donationRequestservice.Setup(repos => repos.GetDonationRequestByNgoId(ngoId));
                var result = await _donationRequestServices.GetDonationRequestByNgoId(ngoId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to list all donations by donor Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAllDonations_ByDonorId()
        {
            //Arrange
            var res = false;
            int donorId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                donationRequestservice.Setup(repos => repos.GetDonationRequestForDonor(donorId));
                var result = await _donationRequestServices.GetDonationRequestForDonor(donorId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
        #endregion 
    }
}
