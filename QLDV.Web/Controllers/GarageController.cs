using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDV.BLL;
using QLDV.Common.Req;
using QLDV.Common.Rsp;

namespace QLDV.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GarageController : ControllerBase
    {
        private GarageSvc garageSvc;

        public GarageController()
        {
            garageSvc = new GarageSvc();
        }

        [HttpGet("get")]
        public IActionResult getGarage([FromQuery] string nameGarage = "get-all")
        {
            var res = new SingleRsp();
            res = garageSvc.GetGarage(nameGarage);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetGarageById(int id)
        {
            try
            {
                var res = new SingleRsp();
                res = garageSvc.Read(id);
                if (res.Data == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy garage");
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("create")]
        public IActionResult CreateGarage([FromBody] GarageReq garageReq)
        {
            var res = garageSvc.CreateGarage(garageReq);
            return Ok(res);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateGarage([FromBody] GarageReq garageReq, int id)
        {
            var res = garageSvc.UpdateGarage(garageReq, id);
            return Ok(res);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteGarageById(int id)
        {
            var res = new SingleRsp();
            res = garageSvc.Delete(id);
            return Ok(res);
        }
    }
}
