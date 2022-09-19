using Microsoft.EntityFrameworkCore;
using QLDV.Common.Rsp;
using QLDV.Common.Req;
using QLDV.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDV.Common.DAL;
using Microsoft.Data.SqlClient;

namespace QLDV.DAL
{
    public class StatsRep
    {
        public SingleRsp StatsQuantityTicket(int month)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    try
                    {
                        string StoredProc = "exec so_luong_ve_booking_theo_chuyen_xe_theo_thang " +
                             "@thang = " + month;
                        command.CommandText = StoredProc;
                        command.CommandType = System.Data.CommandType.Text;

                        context.Database.OpenConnection();

                        List<StatsQuantityTicketReq> entitys = new List<StatsQuantityTicketReq>();
                        using (var result = command.ExecuteReader())
                        {
                            while (result.Read())
                            {
                                StatsQuantityTicketReq req = new StatsQuantityTicketReq();
                                req.ChuyenXeId = (int)result[0];
                                req.Start = (string)result[1];
                                req.Finish = (string)result[2];
                                req.Quantity = (int)result[3];
                                entitys.Add(req);
                            }

                            res.Data = entitys;
                        }

                    }
                    catch (Exception ex)
                    {
                        res.SetError(message: ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}