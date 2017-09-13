using System;
using System.Linq.Expressions;
using DotNet.Model.Entity;
using System.Collections.Generic;
using DotNet.Dto;

namespace DotNet.IService
{
    public interface IUserAccountService
    {
        IEnumerable<UserAccount> GetUserAccount(Expression<Func<UserAccount, bool>> whereLambda);
        bool AddUser(RegisterDto regModel);
    }
}