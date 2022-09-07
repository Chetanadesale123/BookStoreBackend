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
    }
}
