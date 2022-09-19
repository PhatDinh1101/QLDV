using QLDV.Common.DAL;
using QLDV.Common.Rsp;
using QLDV.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDV.DAL
{
    public class GarageRep : GenericRep<QLDVXKContext, Garage>
    {

        public override Garage Read(int id)
        {
            var res = All.FirstOrDefault(p => p.GarageId == id);
            return res;
        }

        public SingleRsp GetGarage(string nameGarage)
        {
            var res = new SingleRsp();
            object data;
            try
            {
                if (nameGarage == "get-all")
                    data = All;
                else
                    data = All.Where(p => p.Name.Contains(nameGarage));

                res.SetData("200", data);
            }
            catch (Exception ex)
            {
                res.SetError(message: ex.StackTrace);
            }

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
                        var m = All.First(i => i.GarageId == id);
                        var p = context.Garages.Remove(m);
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

        public SingleRsp CreateGarage(Garage garage)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Garages.Add(garage);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = garage;
                        res.SetMessage("Created complete");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(message: ex.StackTrace);
                    }
                }
            }
            return res;
        }


        public SingleRsp UpdateGarage(Garage garage)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Garages.Update(garage);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = garage;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(message: ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
