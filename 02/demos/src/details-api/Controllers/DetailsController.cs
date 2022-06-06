using BookInfo.Details.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BookInfo.Details.Controllers
{
    [ApiController]
    [Route("details")]
    public class DetailsController : ControllerBase
    {
        private static Random _Random = new Random();
        private static List<string> _RequestIDs = new List<string>();
                
        protected readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public DetailsController(IConfiguration configuration, ILogger<DetailsController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_configuration["SERVICE_VERSION"]== "v-unavailable")
            {
                return StatusCode(503);
            }
            if (_configuration["SERVICE_VERSION"] == "v-timeout")
            {
                Thread.Sleep(30 * 1000);
                return StatusCode(500);
            }
            if (_configuration["SERVICE_VERSION"] == "v-timeout-first-call")
            {
                var requestId = Request.Headers["x-request-id"];
                if (!_RequestIDs.Contains(requestId))
                {
                    _logger.LogInformation($"NEW request, ID: {requestId}; will timeout");
                    _RequestIDs.Add(requestId);
                    Thread.Sleep(30 * 1000);
                    return StatusCode(500);
                }
                _logger.LogInformation($"REPEAT request, ID: {requestId}; will respond");
            }
            if (_configuration["SERVICE_VERSION"] == "v-50-50-unhealthy" && Status.Healthy == false)
            {
                var statusCode = (_Random.Next(0,100) > 50) ? 500 : 503;
                _logger.LogInformation($"UNHEALTHY, returning {statusCode}");
                return StatusCode(statusCode);
            }
            var book = new BookDetails
            {
                Id = id,
                Author = "William Shakespeare",
                Year = 1595,
                Type = "paperback",
                Pages = 200,
                Publisher = "PublisherB",
                Language = "English",
                Isbn10 = "1234567890",
                Isbn13 = "123-1234567890"
            };
            _logger.LogInformation($"HEALTHY, returning 200");
            return Ok(book);
        }
    }
}