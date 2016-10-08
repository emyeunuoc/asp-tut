using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using OnlineShop.Common;
using PagedList;
namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /Admin/User/
        public ActionResult Index(string searchString, int page = 1,int pageSize = 3)
        {
            var dao = new UserDao();
            var model = dao.ListAllPagging(searchString,page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptedMD5pas = Encryptor.MD5Hash(user.Password);
                user.Password = Encryptor.MD5Hash(encryptedMD5pas);
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Them user that bai");
                }
            }
            else
            {
                ModelState.AddModelError("", "Them User thanh cong");
            }
            return View("Index");
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().viewDetail(id);
            
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptedMD5pas = Encryptor.MD5Hash(user.Password);
                user.Password = Encryptor.MD5Hash(encryptedMD5pas);
                bool result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Sua user thanh cong");
                }
            }
            return View("index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new UserDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
	}
}