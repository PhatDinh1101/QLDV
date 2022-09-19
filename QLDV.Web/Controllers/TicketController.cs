using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Common.Req;
using QLDV.BLL;
using QLDV.Common.Req;
using QLDV.Common.Rsp;

namespace QLDV.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private TicketSvc ticketSvc;
        public TicketController()
        {
            ticketSvc = new TicketSvc();
        }

        [HttpGet("get-all")]
        public IActionResult getAllChuyenXe()
        {
            var res = new SingleRsp();
            res.Data = ticketSvc.All;
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult GetChuyenXeById(int id)
        {
            try
            {
                var res = new SingleRsp();
                res = ticketSvc.Read(id);
                if (res.Data == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy vé xe");
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("create-ticket")]
        public IActionResult CreateTicket([FromBody] TicketReq reqTicket)
        {
            var res = new SingleRsp();
            res = ticketSvc.CreateTicket(reqTicket);
            return Ok(res);
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateProduct([FromBody] TicketReq reqTicket, int id)
        {
            var res = ticketSvc.UpdateTicket(reqTicket, id);
            return Ok(res);
        }
        
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteTicketById(int id)
        {
            var res = new SingleRsp();
            res = ticketSvc.Delete(id);
            return Ok(res);
        }
    }
}
