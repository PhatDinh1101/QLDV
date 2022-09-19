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
    public class ChuyenXeController : ControllerBase
    {
        private ChuyenXeSvc chuyenxeSvc;
        public ChuyenXeController()
        {
            chuyenxeSvc = new ChuyenXeSvc();
        }

        [HttpGet("get-all")]
        public IActionResult getAllChuyenXe()
        {
            var res = new SingleRsp();
            res.Data = chuyenxeSvc.All;
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult GetChuyenXeById(int id)
        {
            try
            {
                var res = new SingleRsp();
                res = chuyenxeSvc.Read(id);
                if (res.Data == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy chuyến xe");
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("create-chuyenxe")]
        public IActionResult CreateProduct([FromBody] ChuyenXeReq reqChuyenxe)
        {
            var res = new SingleRsp();
            res = chuyenxeSvc.CreateChuyenXe(reqChuyenxe);
            return Ok(res);
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateProduct([FromBody] ChuyenXeReq reqChuyenxe, int id)
        {
            var res = chuyenxeSvc.UpdateChuyenXe(reqChuyenxe, id);
            return Ok(res);
        }
        
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteChuyenXeById(int id)
        {
            var res = new SingleRsp();
            res = chuyenxeSvc.Delete(id);
            return Ok(res);
        }
    }
}
