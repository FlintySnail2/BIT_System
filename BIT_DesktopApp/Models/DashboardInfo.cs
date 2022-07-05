using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class DashboardInfo 
    {
        private SQLHelper _db;

        public DashboardInfo()
        {
            _db = new SQLHelper();

        }

        public int ActiveJobs()
        {
            
            string acceptedSql = @"SELECT 
	                                COUNT(JobId) AS [Active Jobs]
                                FROM 
	                                Job
                                WHERE
                                	Status = 'Accepted'";
            return _db.ExecuteNonQuery(acceptedSql);
        }

        public int PendingJobs()
        {
            string pendingSql = @"SELECT 
                                	COUNT(JobId) AS [Pending Jobs]
                                FROM 
                                	Job
                                WHERE
                                	Status = 'Pending'";
            return _db.ExecuteNonQuery(pendingSql);
        }

        public int CompletedJobs()
        {
            string completedSql = @"SELECT 
                            	COUNT(JobId) AS [Completed Jobs]
                            FROM 
                            	Job
                            WHERE
                            	Status = 'Completed'";
            return _db.ExecuteNonQuery(completedSql);
        }

        public int RejectedJobs()
        {
            string rejectedJobs = @"SELECT 
                                    	COUNT(JobId) AS [Rejected Jobs]
                                    FROM 
                                    	Job
                                    WHERE
                                    	Status = 'Rejected'";
            return _db.ExecuteNonQuery(rejectedJobs);
        }
    }
}
