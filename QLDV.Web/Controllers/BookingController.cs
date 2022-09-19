using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDV.BLL;
using QLDV.Common.Req;
using QLDV.Common.Rsp;

namespace QLDV.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingSvc bookingSvc;
        public BookingController()
        {
            bookingSvc = new BookingSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllBooking()
        {
            var res = new SingleRsp();
            res.Data = bookingSvc.All;
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult GetBookingByID(int id)
        {
            try
            {
                var res = new SingleRsp();
                res = bookingSvc.Read(id);
                if (res.Data == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy booking");
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create-booking")]
        public IActionResult GetBookingById([FromBody] BookingReq bookingReq)
        {
            var res = bookingSvc.CreateBooking(bookingReq);
            return Ok(res);
        }

        [HttpPut("update-booking")]
        public IActionResult UpdateBooking([FromBody] BookingReq reqBooking, int id)
        {
            var res = bookingSvc.UpdateBooking(reqBooking, id);
            return Ok(res);
        }
        [HttpDelete("delete-by-id")]
        public IActionResult DeleteBookingId(int id)
        {
            var res = new SingleRsp();
            res = bookingSvc.Delete(id);
            return Ok(res);
        }


    }
}
