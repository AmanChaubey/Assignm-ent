using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Dapper;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Assignment
{
    class DB
    {

        /// <summary>
        /// Get Discount List
        /// </summary>
        /// <returns>DiscountDTO List</returns>
        public List<DiscountDTO> GetDiscountList()
        {
            List<DiscountDTO> discountDTOs = new List<DiscountDTO>();
            try
            {
                using (IDbConnection db = new SqlConnection(Utility.GetConfiguration()))
                {
                    var details = db.QueryMultiple("PR_GetDiscountList", null, commandType: CommandType.StoredProcedure);

                    List<DiscountDTO> discounts = details.Read<DiscountDTO>().ToList();
                    if (discounts != null)
                    {
                        discountDTOs = discounts;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return discountDTOs;
        }

        /// <summary>
        /// Save sales event
        /// </summary>
        /// <param name="salesEventDTO">salesEventDTO</param>
        /// <returns>return identity</returns>
        public int SaveSalesEvent(SalesEventDTO salesEventDTO)
        {
            int result = 0;
            try
            {
                var param = new DynamicParameters();
                param.Add("@DiscountId", salesEventDTO, DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@DiscountAmount", salesEventDTO, DbType.Decimal, direction: ParameterDirection.Input);
                param.Add("@EventPrice", salesEventDTO, DbType.Decimal, direction: ParameterDirection.Input);
                param.Add("@StartDate", salesEventDTO, DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@EndDate", salesEventDTO, DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@IsActive", salesEventDTO, DbType.Boolean, direction: ParameterDirection.Input);
                param.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);
                using (IDbConnection db = new SqlConnection(Utility.GetConfiguration()))
                {
                    db.Execute("PR_SaveSalesEvent", param, commandType: CommandType.StoredProcedure);
                    result = param.Get<int>("@ReturnValue");
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

    }
}
