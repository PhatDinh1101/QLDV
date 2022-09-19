using QLBH.Common.Req;
using QLDV.Common.BLL;
using QLDV.Common.Rsp;
using QLDV.DAL;
using QLDV.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDV.BLL
{
    public class ChuyenXeSvc:GenericSvc<ChuyenXeRep, ChuyenXe>
    {
        private ChuyenXeRep chuyenxeRep;
        public ChuyenXeSvc()
        {
            chuyenxeRep = new ChuyenXeRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Remove(id);
            res.SetMessage(m);

            return res;
        }

        public SingleRsp CreateChuyenXe(ChuyenXeReq chuyenXeReq)
        {
            var res = new SingleRsp();
            ChuyenXe chuyenxe = new ChuyenXe();
            chuyenxe.GarageId = chuyenXeReq.GarageId;
            chuyenxe.Start = chuyenXeReq.Start;
            chuyenxe.Finish = chuyenXeReq.Finish;

            res = chuyenxeRep.CreateChuyenXe(chuyenxe);
            return res;
        }

       
        public SingleRsp UpdateChuyenXe(ChuyenXeReq chuyenXeReq, int id)
        {
            var res = new SingleRsp();
            ChuyenXe chuyenxe = new ChuyenXe();
            chuyenxe = id > 0 ? _rep.Read(id) : _rep.Read(id);
            if (chuyenXeReq.GarageId > 0)
                chuyenxe.GarageId = chuyenXeReq.GarageId;
            chuyenxe.Start = chuyenXeReq.Start;
            chuyenxe.Finish = chuyenXeReq.Finish;

            res = chuyenxeRep.UpdateChuyenXe(chuyenxe);

            return res;
        }
    }
}
