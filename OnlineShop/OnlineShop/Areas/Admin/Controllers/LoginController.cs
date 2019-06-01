using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserDao dao = new UserDao();
                bool res = dao.Login(model.UserName, model.Password);
                if(res == true)
                {
                    var user = dao.GetUserByUserName(model.UserName);
                    UserLoginCommon userSession = new UserLoginCommon();
                    userSession.UserName = user.UserName;
                    userSession.UserName = user.Password;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "UserName hoac Password khong dung!");
                }
            }
            return View("Index");
        }
    }
}