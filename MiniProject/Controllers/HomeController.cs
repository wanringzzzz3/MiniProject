using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    public class HomeController : BaseController
    {
        private readonly MyDataContext _context;

        public HomeController(MyDataContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == UserDefault && model.Password == PasswordDefault)
                {
                    var user = _context.Users.FirstOrDefault(e => e.Username == model.Username);
                    if (user != null)
                    {
                        SetAuthentication(user);
                        return Redirect(Url.Action("RoomManage", "Admin"));
                    }
                }
                else
                {
                    var account = CheckLogin(model);
                    if (account != null)
                    {
                        //if (!string.IsNullOrEmpty(model.ReturnUrl))
                        //{
                        //    return Redirect(model.ReturnUrl);
                        //}

                        return Redirect(Url.Action("RoomManage", "Admin"));
                    }
                }
            }
            return View(model);
        }
        private string CheckAccountError(User user)
        {
            if (user == null)//Có tồn tại không?
            {
                return "Account not exist!";
            }
            //else if (user.IsActive())//Có kích hoạt không?
            //{
            //    return MessageConstants.AccountInactive;
            //}
            else if (!user.IsValid())//Có bị xóa không?
            {
                return "Account has been deleted!";
            }

            return string.Empty;
        }

        private bool CheckAccount(User user)
        {
            var error = CheckAccountError(user);
            if (!string.IsNullOrEmpty(error))
            {
                SetCustomError(error);
                return false;
            }

            return true;
        }

        private bool CheckLoginAndAuthentication(User user)
        {
            if (CheckAccount(user))
            {
                SetAuthentication(user);
                return true;
            }

            return false;
        }
        private User CheckLogin(LoginModel login)
        {
            var user = Login(login.Username, login.Password);
            if (CheckLoginAndAuthentication(user))
            {
                return user;
            }

            return null;
        }

        private User Login(string identity, string password)
        {
            if (string.IsNullOrEmpty(identity))
                throw new ArgumentNullException("identity");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            try
            {
                var user = GetAccountByIdentity(identity);

                if (user != null)
                {
                    IPasswordEncrypter _passwordEncrypter = new Pbkdf2Encrypter();
                    if (_passwordEncrypter.ValidatePassword(password, user.Password))
                        return user;
                }
                //login failed.
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
                //return null;
            }
        }

        private User GetAccountByIdentity(string identity)
        {
            identity = identity.ToLower();
            return _context.Users.FirstOrDefault(u =>
                u.Username.ToLower().Equals(identity));
        }

        private void SetAuthentication(User user)
        {
            //var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
            //        new Claim(ClaimTypes.NameIdentifier, user.Username),
            //        new Claim(ClaimTypes.Name, user.Full_Name),
            //        new Claim(ClaimTypes.Email, user.Email),
            //        new Claim(ClaimTypes.MobilePhone, user.User_Phone),
            //        new Claim(ClaimTypes.Anonymous, user.Status.ToString()),
            //    };

            //var binFormatter = new BinaryFormatter();
            //var mStream = new MemoryStream();
            //binFormatter.Serialize(mStream, claims);

            ////This gives you the byte array.


            //if (HttpContext.Session != null)
            //    HttpContext.Session.Set(SessionKeyUser, mStream.ToArray());

            if (HttpContext.Session != null)
            {
                HttpContext.Session.SetInt32(SessionKeyUser, user.Id);
                HttpContext.Session.SetString(SessionKeyUserName, user.Username);
            }

        }
    }
}
