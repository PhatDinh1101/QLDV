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
    public class UserRep : GenericRep<QLDVXKContext, User>
    {
        public UserRep() { }

        public override User Read(int id)
        {
            var res = All.FirstOrDefault(c => c.UserId == id);
            return res;
        }

        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Add(user);
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

        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();
            if (user.UserId <= 0)
            {
                res.SetError("Error!");
                return res;
            }
            else
            {
                using (var context = new QLDVXKContext())
                {
                    using (var tran = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var cat = context.Users.Update(user);
                            context.SaveChanges();
                            tran.Commit();
                            res.Data = user;
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
        public SingleRsp DeleteUser(int id)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var snack = context.Users.Remove(context.Users.FirstOrDefault(m => m.UserId == id));
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
    }
}
