using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FileConfigurationProviderDemo.Controllers
{
    public class TestController : Controller
    {
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IActionResult Index()
        {
            var hasValueCount = 0;
            var noValueCount = 0;
            for (var i = 0; i < 1000000; i++)
            {
                var value = _configuration["key"];
                if (string.IsNullOrEmpty(value))
                {
                    noValueCount++;
                }
                else
                {
                    hasValueCount++;
                }
            }
            return Content($"Has Value:{hasValueCount},no Value:{noValueCount}");
        }
    }
}