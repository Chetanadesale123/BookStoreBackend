using BusinessLayer.Interfaces;
using CommonLayer.UserModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost("Register")]
        public ActionResult UserRegister(UserDataModel usermodel)
        {
            try
            {
                var user = this.userBL.Register(usermodel);
                if (user != null)
                {
                    return this.Ok(new { success = true, message = "Registration Successfully", data = user });
                }
                return this.BadRequest(new { success = false, message = "Email Already Exits", data = user });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Login")]
        public IActionResult UserLogin(LogInModel userLoginModel)
        {
            try
            {
                var result = this.userBL.UserLogin(userLoginModel);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Login Successful.. !", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Login failed.. !!" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
