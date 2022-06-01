using BIT_DesktopApp.Models;
using BIT_DesktopApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.ObjectModel;

namespace BitTest
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void testclient()
        {
            Client newclient = new Client()
            {
                OrganisationName = "billtech industries",
                ContactName = "bill brown",
                Phone = "0470123321",
                Email = "bill@billtech.com"
            };
            string expectedclientname = "billtech industries";
            string expectedcontactname = "bill brown";
            string expectedphone = "0470123321";
            string expectedemail = "bill@billtech.com";

            Assert.AreEqual(newclient.OrganisationName, expectedclientname);
            Assert.AreEqual(newclient.ContactName, expectedcontactname);
            Assert.AreEqual(newclient.Phone, expectedphone);
            Assert.AreEqual(newclient.Email, expectedemail);
        }

        // INTEGRATION TESTING MOQ
        [TestMethod]
        public void TestClientViewModel()
        {
            ClientViewModel clientVM = new ClientViewModel();
            int count = clientVM.Clients.Count;
            Assert.AreEqual(4, count);
        }


        // MOCK TESTING WITH OBSERVABLE COLLECTION
        [TestMethod]
        public void TestClientCollectionMock()
        {
            ObservableCollection<Client> mockClients = new ObservableCollection<Client>();
            mockClients.Add(new Client
            {
                ClientId = 1,
                OrganisationName = "BillTech Industries",
                ContactName = "Bill Brown",
                Phone = "0470123321",
                Email = "Bill@BillTech.com"
            });
            mockClients.Add(new Client()
            {
                ClientId = 2,
                OrganisationName = "Datacom Solutions",
                ContactName = "Fred Data",
                Phone = "049310000",
                Email = "Fred@Datacom.com"
            });
            mockClients.Add(new Client
            {
                ClientId = 3,
                OrganisationName = "Integrated Tech Solutions.",
                ContactName = "Eugene White",
                Phone = "0490999999",
                Email = "EugeneWhite@IntTech.com"
            });
            mockClients.Add(new Client
            {
                ClientId = 4,
                OrganisationName = "Cyber Security Solutions",
                ContactName = "Tim Secure",
                Phone = "0477777777",
                Email = "TimSecure@Cyber.com"
            });

            Mock<ClientViewModel> mockClientVM = new Mock<ClientViewModel>();
            mockClientVM.Setup(mc => mc.GetClients()).Returns(mockClients);
            int count = mockClientVM.Object.GetClients().Count;
            Assert.AreEqual(4, count);
        }
    }
}
