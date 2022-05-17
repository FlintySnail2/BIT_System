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
        public void TestClient()
        {
            Client newClient = new Client()
            {
                OrganisationName = "BillTech Industries",
                ContactName = "Bill Brown",
                Phone = "0470123321",
                Email = "Bill@BillTech.com"
            };
            string expectedClientName = "BillTech Industries";
            string expectedContactName = "Bill Brown";
            string expectedPhone = "0470123321";
            string expectedEmail = "Bill@BillTech.com";

            Assert.AreEqual(newClient.OrganisationName, expectedClientName);
            Assert.AreEqual(newClient.ContactName, expectedContactName);
            Assert.AreEqual(newClient.Phone, expectedPhone);
            Assert.AreEqual(newClient.Email, expectedEmail);
        }        

        //INTEGRATION TESTING MOQ
        [TestMethod]
        public void TestClientViewModel()
        {
            ClientViewModel clientVM = new ClientViewModel();
            int count = clientVM.Clients.Count;
            Assert.AreEqual(4, count);
        }


        //MOCK TESTING WITH OBSERVABLE COLLECTION
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
