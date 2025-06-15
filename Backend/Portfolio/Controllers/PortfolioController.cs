using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.Interfaces;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private IPortfolio _portfolio;
        private readonly string _connstring;

        public PortfolioController(IPortfolio portfolio, IConfiguration configuration)
        {
            _portfolio = portfolio;
            _connstring = configuration.GetConnectionString("DefaultConnection");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllData() {
            var responseList = await _portfolio.GetAllAsync(_connstring);
            return Ok(responseList);
        }
    }
}
