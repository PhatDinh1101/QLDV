using Microsoft.EntityFrameworkCore.Query;
using QLDV.Common.BLL;
using QLDV.Common.Req;
using QLDV.Common.Rsp;
using QLDV.DAL;
using QLDV.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace QLDV.BLL
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        private UserRep req;
        public UserSvc()
        {
            req = new UserRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var user = _rep.Read(id);
            if (user != null)
            {
                res.Data = user;
            }
            else
            {
                res.SetError("Can not found any item!");
            }
            return res;
        }

        public override SingleRsp Update(User u)
        {
            var res = new SingleRsp();

            var m1 = u.UserId > 0 ? _rep.Read(u.UserId) : _rep.Read(u.UserId);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(u);
                res.Data = u;
            }

            return res;
        }

        public SingleRsp CreateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserName = userReq.UserName;
            user.PassWord = userReq.PassWord;
            user.FirstName = userReq.FirstName;
            user.LastName = userReq.LastName;
            user.Avatar = userReq.Avatar;
            user.Status = userReq.Status;
            res = req.CreateUser(user);
            return res;
        }

        public SingleRsp UpdateUser(int Id, UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.UserId = Id;
            user.UserName = userReq.UserName;
            user.PassWord = userReq.PassWord;
            user.FirstName = userReq.FirstName;
            user.LastName = userReq.LastName;
            user.Avatar = userReq.Avatar;
            user.Status = userReq.Status;
            res = req.UpdateUser(user);
            return res;
        }

        public SingleRsp DeleteUser(int id)
        {
            return _rep.DeleteUser(id);
        }
    }
}
