using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Instructure.DataAccess
{
    public class FeeRepository:BaseRepository, IFeeRepository
    {
        public Fee GetFeeByFeeName(string feeName)
        {
            var procName = "proc_Get_FeeByFeeName";
            var fee = dbConnection.Query<Fee>(procName, new { FeeName = feeName }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return fee;
        }

        public IEnumerable GetFeeIsStopFollow()
        {
            var procName = "proc_Get_FeeIsStopFollow";
            var fees = dbConnection.Query<Fee>(procName, commandType: CommandType.StoredProcedure).ToList();
            return fees;
        }

    }
}
