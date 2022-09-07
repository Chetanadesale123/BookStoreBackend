using CommonLayer.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        public UserDataModel Register(UserDataModel usermodel);
    }
}
