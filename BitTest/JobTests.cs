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
    public class JobTests
    {
        [TestMethod]
        public void TestJob()
        {
            Job newJob = new Job()
            {
                Priority = "High",
                DistanceTravelled = "35",
                SkillReq = "Network Engineer",
                Status = "Assigned"
            };
            string expectedPriority = "High";
            string expectedDistanceTravelled = "35";
            string expectedSkillReq = "Network Engineer";
            string expectedStatus = "Assigned";

            Assert.AreEqual(expectedPriority, newJob.Priority);
            Assert.AreEqual(expectedDistanceTravelled, newJob.DistanceTravelled);
            Assert.AreEqual(expectedSkillReq, newJob.SkillReq);
            Assert.AreEqual(expectedStatus, newJob.Status);
        }

        [TestMethod]
        public void TestJobViewModel()
        {
            JobViewModel jobVM = new JobViewModel();
            int count = jobVM.Jobs.Count;
            Assert.AreEqual(6, count);
        }

        [TestMethod]
        public void TestContractorCollectionMock()
        {
            ObservableCollection<Job> mockJobs = new ObservableCollection<Job>();
            mockJobs.Add(new Job
            {
                JobId = 1,
                Priority = "High",
                DistanceTravelled = "35",
                SkillReq = "Network Engineer",
                Status = "Assigned"
            });
            mockJobs.Add(new Job
            {
                JobId = 2,
                Priority = "Medium",
                DistanceTravelled = "12",
                SkillReq = "System Analyst",
                Status = "Completed"
            });
            mockJobs.Add(new Job
            {
                JobId = 3,
                Priority = "Medium",
                DistanceTravelled = "5",
                SkillReq = "C# Programmer",
                Status = "Completed"
            });
            mockJobs.Add(new Job
            {
                JobId = 4,
                Priority = "Low",
                DistanceTravelled = "32",
                SkillReq = "Developer",
                Status = "Completed"
            });
            mockJobs.Add(new Job
            {
                JobId = 5,
                Priority = "High",
                DistanceTravelled = "0",
                SkillReq = "Network Engineer",
                Status = "Accepted"
            });
            Mock<JobViewModel> mockJobVM = new Mock<JobViewModel>();
            mockJobVM.Setup(mc => mc.GetJobs()).Returns(mockJobs);
            int count = mockJobVM.Object.GetJobs().Count;
            Assert.AreEqual(10, count);
        }
    }
}
