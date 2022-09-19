using Microsoft.AspNetCore.Mvc;
using QLDV.BLL;
using QLDV.Common.Rsp;

namespace QLDV.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private StatsSvc statsSvc;

        public StatsController()
        {
            statsSvc = new StatsSvc();
        }

        [HttpGet("get-stats")]
        public IActionResult getAllChuyenXe(int month)
        {
            var res = new SingleRsp();
            res = statsSvc.StatsQuantityTicket(month);
            return Ok(res);
        }
    }
}