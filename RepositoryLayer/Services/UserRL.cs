using CommonLayer.UserModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly IConfiguration configuration;
        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public UserDataModel Register(UserDataModel usermodel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:BookStoreConnection"]))
                {
                    SqlCommand cmd = new SqlCommand("UserRegister", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FullName", usermodel.FullName);
                    cmd.Parameters.AddWithValue("@Email", usermodel.Email);
                    cmd.Parameters.AddWithValue("@Password", usermodel.Password);
                    cmd.Parameters.AddWithValue("@MobileNumber", usermodel.MobileNumber);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
                    {
                        return usermodel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
