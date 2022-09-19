using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.Common.Req
{
    public class ChuyenXeReq
    {
        public ChuyenXeReq()
        {
            GarageId = -1;
            Finish = "null";
            Start = "null";
        }
        public ChuyenXeReq(int GarageId, string Start, string Finish)
        {
            GarageId = GarageId;
            Start = Start;
            Finish = Finish;
        }
        public int? GarageId { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }
    }
}
