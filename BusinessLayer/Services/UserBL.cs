using BusinessLayer.Interfaces;
using CommonLayer.UserModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public UserDataModel Register(UserDataModel usermodel)
        {
            try
            {
                return userRL.Register(usermodel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
