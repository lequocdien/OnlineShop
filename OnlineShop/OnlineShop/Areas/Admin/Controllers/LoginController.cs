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
                int res = dao.Login(model.UserName, MaHoaMD5.GetMD5(model.Password));
                if(res == 1)
                {
                    var user = dao.GetUserByUserName(model.UserName);
                    UserLoginCommon userSession = new UserLoginCommon();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    return RedirectToAction("Index", "Home");
                }
                else if(res == 0)
                {
                    ModelState.AddModelError("", "Username khong dung!");
                }
                else if(res == -1)
                {
                    ModelState.AddModelError("", "Password khong dung!");
                }
                else if(res == -2)
                {
                    ModelState.AddModelError("", "Tai khoan nay da bi khoa!");
                }

            }
            return View("Index");
        }
    }
}