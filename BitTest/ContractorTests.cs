using BIT_DesktopApp.Models;
using BIT_DesktopApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTest
{
    [TestClass]
    public class ContractorTests
    {
        [TestMethod]
        public void TestContractor()
        {
            Contractor newContractor = new Contractor()
            {
                ContractorName = "Steven Good",
                Phone = "0400987654",
                Email = "StevenGood@mail.com",
                ABN = "00000002N",
                LicenceNumber = "1111110C",
                ContractorRating = "3"
            };
            string expectedContractorName = "Steven Good";
            string expectedPhone = "0400987654";
            string expectedEmail = "StevenGood@mail.com";
            string expectedABN = "00000002N";
            string expectedLicenceNumber = "1111110C";
            string expectedContractorRating = "3";

            Assert.AreEqual(newContractor.ContractorName, expectedContractorName);
            Assert.AreEqual(newContractor.Phone, expectedPhone);
            Assert.AreEqual(newContractor.Email, expectedEmail);
            Assert.AreEqual(newContractor.ABN, expectedABN);
            Assert.AreEqual(newContractor.LicenceNumber, expectedLicenceNumber);
            Assert.AreEqual(newContractor.ContractorRating, expectedContractorRating);

        }

        [TestMethod]
        public void TestContractorViewModel()
        {
            ContractorViewModel contractorVM = new ContractorViewModel();
            int count = contractorVM.Contractors.Count;
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void TestContractorCollectionMock()
        {
            ObservableCollection<Contractor> mockContractors = new ObservableCollection<Contractor>();
            mockContractors.Add(new Contractor
            {
                ContractorId = 1,
                ContractorName = "Steven Good",
                Phone = "0400987654",
                Email = "StevenGood@mail.com",
                ABN = "00000002N",
                LicenceNumber = "1111110C",
                ContractorRating = "3"
            });
            mockContractors.Add(new Contractor
            {
                ContractorId = 2,
                ContractorName = "Tim Chan",
                Phone = "0450000700",
                Email = "TimChan@mail.com",
                ABN = "00000003N",
                LicenceNumber = "2222220C",
                ContractorRating = "4.5"
            });
            mockContractors.Add(new Contractor
            {
                ContractorId = 3,
                ContractorName = "Terry Lee",
                Phone = "0404900800",
                Email = "TerryLee@mail.com",
                ABN = "00000004N",
                LicenceNumber = "0000001N",
                ContractorRating = "5"
            });
            mockContractors.Add(new Contractor
            {
                ContractorId = 4,
                ContractorName = "Fred Durst",
                Phone = "0475800400",
                Email = "FredDurst@mail.com",
                ABN = "00000005N",
                LicenceNumber = "3333330C",
                ContractorRating = "2"
            });
            Mock<ContractorViewModel> mockContractorVM = new Mock<ContractorViewModel>();
            mockContractorVM.Setup(mc => mc.GetContractors()).Returns(mockContractors);
            int count = mockContractorVM.Object.GetContractors().Count;
            Assert.AreEqual(3, count);
        }
    }
}
