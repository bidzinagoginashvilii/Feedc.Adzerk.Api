using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Feedc.Adzerk.Application.Queries;
using Feedc.Adzerk.Application.Infrastructure;

namespace Feedc.Adzerk.Api.Controllers
{
    [Route("v1/decision")]
    [ApiController]
    public class DecisionController : ControllerBase
    {
        private readonly QueryExecutor _executor;
        public DecisionController(QueryExecutor executor)
        {
            _executor = executor;
        }

        [HttpPost]
        [Route("advertisements")]
        public async Task<IActionResult> GetAdvertisement([FromBody] AdvertisementQuery query)
        {
            try
            {
                var result = await _executor.ExecuteAsync<AdvertisementQuery, IEnumerable<AdvertisementQueryResult>>(query);

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
