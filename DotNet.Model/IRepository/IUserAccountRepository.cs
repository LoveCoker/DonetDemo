using System;
using System.Linq;
using System.Linq.Expressions;
using DotNet.Model.Entity;

namespace DotNet.Model.IRepository
{
    public interface IUserAccountRepository
    {
        IQueryable<UserAccount> GetUserAccounts(Expression<Func<UserAccount, bool>> whereLambda);
    }
}