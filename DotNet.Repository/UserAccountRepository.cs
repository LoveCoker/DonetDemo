using System;
using System.Linq;
using System.Linq.Expressions;
using DotNet.Infrastructure.Interface;
using DotNet.Model.Entity;
using DotNet.Model.IRepository;

namespace DotNet.Repository
{
    public class UserAccountRepository:IUserAccountRepository
    {
        private readonly IQueryable<UserAccount> _userAccounts;
        
        public UserAccountRepository(IDbContext dbContext)
        {
            _userAccounts = dbContext.Set<UserAccount>();
        }
       
        public IQueryable<UserAccount> GetUserAccounts(Expression<Func<UserAccount, bool>> whereLambda)
        {
            return _userAccounts.Where(whereLambda);

        }
    }
}