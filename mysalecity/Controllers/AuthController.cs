
using mysalecity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mysalecity.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user model)
        {
            if (ModelState.IsValid)
            {
                user User = new user(); 
                // поиск пользователя в бд
                
                using (mysale_dbEntities db = new mysale_dbEntities())
                {
                    User = db.users.FirstOrDefault(u => u.login == model.login && u.password == model.password);

                }
                if (User != null)
                {
                    FormsAuthentication.SetAuthCookie(model.login, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Redirect("/Register");
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(user model)
        {
            if (ModelState.IsValid)
            {
                user User = null;
                using (mysale_dbEntities db = new mysale_dbEntities())
                {
                    User = db.users.FirstOrDefault(u => u.login == model.login);
                }
                if (User == null)
                {
                    // создаем нового пользователя
                    using (mysale_dbEntities db = new mysale_dbEntities())
                    {
                        user that = new user
                        {
                            login = model.login,
                            password = model.password,
                            date_birth = model.date_birth,
                            user_status = model.user_status,
                            surname = model.surname,
                            name = model.name,
                            middle_name = model.middle_name
                        };                        
                        db.users.Add(that);
                        db.SaveChanges();
                        
                        User = db.users.Where(u => u.login == model.login && u.password == model.password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (User != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}