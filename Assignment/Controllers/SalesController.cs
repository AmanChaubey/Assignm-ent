using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("sales")]
    public class SalesController : ControllerBase
    {
       
        private readonly ILogger<WeatherForecastController> _logger;

        public SalesController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Save sales event
        /// </summary>
        /// <param name="salesEventDTO">salesEventDTO</param>
        /// <returns>return identity</returns>
        [HttpPost, Route("savesalesevent")]
        public int SaveSalesEvent(SalesEventDTO salesEventDTO)
        {
            DB dB = new DB();
            return dB.SaveSalesEvent(salesEventDTO);
        }

        /// <summary>
        /// Get Discount List
        /// </summary>
        /// <returns>DiscountDTO List</returns>
        [HttpGet, Route("getdiscountlist")]
        public List<DiscountDTO> GetDiscountList()
        {
            DB dB = new DB();
            return dB.GetDiscountList();
        }
    }
}
