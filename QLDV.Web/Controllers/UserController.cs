using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDV.BLL;
using QLDV.Common.Req;
using QLDV.Common.Rsp;

namespace QLDV.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserSvc userSvc;
        public UserController()
        {
            userSvc = new UserSvc();
        }
        [HttpGet("get-user/{Id}")]
        public IActionResult GetUserByID(int Id)
        {
            var res = new SingleRsp();
            res = userSvc.Read(Id);
            return Ok(res);
        }
        [HttpGet("get-all")]
        public IActionResult getAllBooking()
        {
            var res = new SingleRsp();
            res.Data = userSvc.All;
            return Ok(res);
        }

        [HttpPost("create-user")]
        public IActionResult GetUserById([FromBody] UserReq userReq)
        {
            var res = userSvc.CreateUser(userReq);
            return Ok(res);
        }

        [HttpPut("update-user/{Id}")]
        public IActionResult UpdateUser(int Id, [FromBody] UserReq userReq)
        {
            var res = userSvc.UpdateUser(Id, userReq);
            return Ok(res);
        }
        [HttpDelete("delete-user/{Id}")]
        public IActionResult DeleteUserlByID(int Id)
        {
            var res = new SingleRsp();
            res = userSvc.DeleteUser(Id);
            return Ok(res);
        }
    }
}
