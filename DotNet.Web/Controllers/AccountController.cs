using System;
using System.Linq;
using DotNet.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DotNet.Infrastructure.Helper;
using DotNet.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using DotNet.IService;
using DotNet.Model.Enum;
using DotNet.Dto;

namespace DotNet.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAccountService _userAccountService;
        private readonly ICacheWriter _cache;
        public AccountController(IUserAccountService userAccountService, ICacheWriter cache)
        {
            _userAccountService = userAccountService;
            _cache = cache;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Msg = TempData["msg"];
            return View();
        }
        [HttpGet]
        public IActionResult Regist()
        {
            ViewBag.RegMsg = TempData["regMsg"];
            return View();
        }
        [HttpPost]
        public IActionResult CheckLogin(string name, string pwd, string code)
        {
            IActionResult result = null;
            //1 校验验证码
            string sessionCode = HttpContext.Session.GetString("ValidateCode");
            //只用一次 用过之后即清空
            HttpContext.Session.SetString("ValidateCode", string.Empty);

            if (string.IsNullOrWhiteSpace(sessionCode) || string.IsNullOrWhiteSpace(code) || sessionCode.ToLower() != code.ToLower())
            {
                TempData["msg"] = "验证码错误";
                result = RedirectToAction("Login");
            }
            else
            {
                string md5Pwd = MD5Helper.GetStringMD5(pwd);
                var user = _userAccountService.GetUserAccount(u => (u.LoginAccount == name || u.Email == name)
                                                                  && u.LoginPwd == md5Pwd
                                                                  && u.UserState == UserState.Normal).FirstOrDefault();
                if (user == null)
                {
                    TempData["msg"] = "用户名或密码错误";
                    result = RedirectToAction("Login");
                }
                else//登录成功
                {
                    string guid = Guid.NewGuid().ToString();
                    _cache.Set($"user:{guid}", user);
                    Response.Cookies.Append("mysessionId", guid);
                    result = RedirectToAction("Index", "Home");
                }
            }
            return result;
        }
        public FileContentResult CreateCodeImg()
        {
            ValidateCodeHelper helper = new ValidateCodeHelper();
            string code = helper.CreateValidateCode(4);
            HttpContext.Session.SetString("ValidateCode", code);
            var img = helper.CreateValidateGraphic2(code);
            return File(img, @"image/png");
        }
        [HttpPost]
        public IActionResult Regist(RegisterDto regModel)
        {
            IActionResult result;
            if (!string.Equals(regModel.RegPwd, regModel.RegPwdEnsure))
            {
                TempData["regMsg"]="两次密码不一致";
                result = RedirectToAction("Regist");
            }
            else if (_userAccountService.GetUserAccount(r => r.LoginAccount == regModel.RegName).Any()
                    || _userAccountService.GetUserAccount(r => r.Email == regModel.RegEmail).Any())
            {
                TempData["regMsg"] ="账户/Email已存在";
                result = RedirectToAction("Regist");
            }
            else
            {
                //todo 注册
                _userAccountService.AddUser(regModel);
                result = RedirectToAction("Index", "Home");
            }
            return result;
        }
        [HttpPost]
        public IActionResult AccountExit(string value)
        {
            var exit = _userAccountService.GetUserAccount(r => r.LoginAccount == value).Any();
            return new JsonResult(new { exit });
        }
        [HttpPost]
        public IActionResult EmailExit(string value)
        {
            var exit = _userAccountService.GetUserAccount(r => r.Email == value).Any();
            return new JsonResult(new { exit });
        }
    }
}