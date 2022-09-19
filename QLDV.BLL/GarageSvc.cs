using QLDV.Common.BLL;
using QLDV.DAL.Models;
using QLDV.DAL;
using QLDV.Common.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDV.Common.Rsp;
using System.Net.Http.Json;

namespace QLDV.BLL
{
    public class GarageSvc : GenericSvc<GarageRep, Garage>
    {
        private GarageRep garageRep;

        public GarageSvc()
        {
            garageRep = new GarageRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public SingleRsp GetGarage(string nameGarage)
        {
            var res = new SingleRsp();
            res = _rep.GetGarage(nameGarage);
            return res;
        }


        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Remove(id);
            res.SetMessage(m);

            return res;
        }


        public SingleRsp UpdateGarage(GarageReq garageReq, int id)
        {
            var res = new SingleRsp();
            Garage garage = new Garage();
            garage = id > 0 ? _rep.Read(id) : _rep.Read(id);
            if (garage == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                if (string.IsNullOrEmpty(garageReq.Name) == false)
                    garage.Name = garageReq.Name.Trim();
                if (string.IsNullOrEmpty(garageReq.Phone) == false)
                    garage.Phone = garageReq.Phone.Trim();
                if (string.IsNullOrEmpty(garageReq.Email) == false)
                    garage.Email = garageReq.Email.Trim();
            }
            res = garageRep.UpdateGarage(garage);
            return res;
        }

        public SingleRsp CreateGarage(GarageReq garageReq)
        {
            var res = new SingleRsp();
            Garage g = new Garage();
            g.Name = garageReq.Name;
            g.Phone = garageReq.Phone;
            g.Email = garageReq.Email;
            res = garageRep.CreateGarage(g);
            return res;
        }
    }
}
