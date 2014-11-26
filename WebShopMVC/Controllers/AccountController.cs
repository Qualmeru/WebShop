﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using WebShopMVC.WebShopWCF;

namespace WebShopMVC.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        WebShopClient proxy = new WebShopClient();

        [HttpPost]
        public ActionResult Login(string retunUrl)
        {
            ViewBag.retunUrl = retunUrl;
          
            return View();
        }

        public ActionResult Login(ModelPersonDTO person)
        {
            if (ModelState.IsValid)
            {
                var user = proxy.FindUser(person.UserName);
                if (user != null && user.PassWord == sha256(person.PassWord))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return View(ViewBag.retunUrl);
                }
                ModelState.AddModelError("", "Username or password is incorrect!");
                return View();
            }
            ModelState.AddModelError("", "Ops Something went wrong");
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(ModelPersonDTO person)
        {
            proxy.Register(person);
            return View(person);
        }
        private string sha256(string password)
        {
            var crypto = SHA256.Create();
            string hash = string.Empty;
            byte[] hashbyte = crypto.ComputeHash(
                Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte bit in hashbyte)
            {
                hash += bit.ToString("x2");

            }
            return hash;

        }

    }
}
