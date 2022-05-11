using BIT_DesktopApp.Models;
using BIT_DesktopApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BitTest
{
    [TestClass]
    public class CLientTests
    {
        //[TestMethod]
        //public void TestNames()
        //{
        //    Client newClient = new Client();

        //    newClient.ContactName = " " //Hard coded names are fine 
 
        //}

        //public void TestRegion()
        //{

        //}

        //public void TestSomething()
        //{

        //}

        //INTEGRATION TESTING MOQ
        [TestMethod]
        public void TestClientViewModel()
        {
            ClientViewModel clientVM = new ClientViewModel();
            int count = clientVM.Clients.Count;
            Assert.AreEqual(4, count);
        }
    }
}
