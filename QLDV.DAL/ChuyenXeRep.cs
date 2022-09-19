using QLDV.Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDV.DAL.Models;
using System.Linq;
using QLDV.Common.Rsp;

namespace QLDV.DAL
{
    public class ChuyenXeRep : GenericRep<QLDVXKContext, ChuyenXe>
    {
        public ChuyenXeRep()
        {

        }

        public override ChuyenXe Read(int id)
        {
            var res = All.FirstOrDefault(c => c.ChuyenXeId == id);
            return res;
        }

        public string Remove(int id)
        {
            string message;
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var m = All.First(i => i.ChuyenXeId == id);
                        var p = context.ChuyenXes.Remove(m);
                        context.SaveChanges();
                        tran.Commit();
                        message = "Delete complete";
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        message = "Delete not complete";
                    }
                }
            }

            return message;
        }

        public SingleRsp CreateChuyenXe(ChuyenXe chuyenxe)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.ChuyenXes.Add(chuyenxe);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }


        public SingleRsp UpdateChuyenXe(ChuyenXe chuyenxe)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.ChuyenXes.Update(chuyenxe);
                        context.SaveChanges();
                        res.Data = chuyenxe;
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
