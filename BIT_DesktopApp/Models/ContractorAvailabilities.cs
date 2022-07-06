using BIT_DesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.Models
{
    public class ContractorAvailabilities : List<ContractorAvailability>
    {
        public ContractorAvailabilities(int contractorId)
        {
            SQLHelper db = new SQLHelper();

            string Sql = "SELECT " +
                "          ContractorId,  " +
                         " AvailabilityDate " +
                         " FROM" +
                         "   Availability" +
                         " WHERE" +
                         "   ContractorId = @ContractorId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[0].Value = contractorId;
            DataTable dt = db.ExecuteSQL(Sql, objParams);
            foreach (DataRow dr in dt.Rows)
            {
                ContractorAvailability contractorAvailability= new ContractorAvailability(dr);
                this.Add(contractorAvailability);
            }
                    

        }

        public ContractorAvailabilities()
        {
            SQLHelper db = new SQLHelper();

            string Sql = "SELECT " +
                "          ContractorId, " +
                         " AvailabilityDate" +
                         " FROM" +
                         "   Availability";
            DataTable dt = db.ExecuteSQL(Sql);
            foreach (DataRow dr in dt.Rows)
            {
                ContractorAvailability contractorAvailability = new ContractorAvailability(dr);
                this.Add(contractorAvailability);
            }


        }


    }
    }
