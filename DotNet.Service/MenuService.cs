using System;
using System.Linq;
using DotNet.Infrastructure.Interface;
using DotNet.Model;
using DotNet.Model.IRepository;

namespace DotNet.Service
{
    public partial class MenuService
    {
        
        private IUnitOfWork _unitOfWork;
        private IMenuRepository _menuRepository;

        public MenuService(IUnitOfWork unitOfWork,IMenuRepository menuRepository)
        {
            _unitOfWork = unitOfWork;
            _menuRepository = menuRepository;
        }
        
    }
}