using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DotNet.Dto;
using DotNet.Infrastructure.Helper;
using DotNet.Infrastructure.Interface;
using DotNet.IService;
using DotNet.Model;
using DotNet.Model.Entity;
using DotNet.Model.Enum;
using DotNet.Model.IRepository;

namespace DotNet.Service
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAccountRepository _userAccountRepository;

        public UserAccountService(IUnitOfWork unitOfWork, IUserAccountRepository userAccountRepository)
        {
            _unitOfWork = unitOfWork;
            _userAccountRepository = userAccountRepository;
        }

        public bool AddUser(RegisterDto regModel)
        {
            UserAccount model = new UserAccount
            {
                LoginAccount = regModel.RegName,
                Email = regModel.RegEmail,
                LoginPwd = MD5Helper.GetStringMD5(regModel.RegPwd),
                UserDetail = new UserDetail { NickName = regModel.RegNickName },
                UserState = UserState.Normal
            };
            _unitOfWork.RegisterNew(model);
            return _unitOfWork.Commit();
        }

        public IEnumerable<UserAccount> GetUserAccount(Expression<Func<UserAccount, bool>> whereLambda)
        {
            return _userAccountRepository.GetUserAccounts(whereLambda);
        }
    }
}