using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Conditio.API.Controllers
{
    [Route("api/[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly AppInsightsAPIOptions _appInsightsOptions;

        public SettingsController(IOptions<AppInsightsAPIOptions> appInsightsOptions)
        {
            _appInsightsOptions = appInsightsOptions.Value;
        }

        // GET: api/settings
        [HttpGet()]
        public async Task<APIOptions> Get()
        {
            var options = new APIOptions()
            {
                AppInsights = _appInsightsOptions
            };
            return await Task.FromResult(options);
        }
    }
}