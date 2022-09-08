using CommonLayer.UserModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        public string UserLogin(LogInModel userLoginModel)
        {
            SqlConnection sqlConnection = new SqlConnection(configuration["ConnectionStrings:BookStoreConnection"]);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("LogIn", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", userLoginModel.Email);
                    cmd.Parameters.AddWithValue("@Password", userLoginModel.Password);
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader();
                    GetAllUsersModel response = new GetAllUsersModel();
                    if (reader.Read())
                    {
                        response.UserId = reader["UserId"] == DBNull.Value ? default : reader.GetInt32("UserId");
                        response.Email = reader["Email"] == DBNull.Value ? default : reader.GetString("Email");
                        response.Password = reader["Password"] == DBNull.Value ? default : reader.GetString("Password");
                    }
                    return GenerateJWTSecurityToken(response.Email, response.UserId);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private string GenerateJWTSecurityToken(string Email, int UserId)
        {
            try
            {
                // generate token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("Email", Email),
                    new Claim("UserId",UserId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string EncryptPassword(string Password)
        {
            try
            {
                if (Password == null)
                {
                    return null;
                }
                else
                {
                    byte[] b = Encoding.ASCII.GetBytes(Password);
                    string encrypted = Convert.ToBase64String(b);
                    return encrypted;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string DecryptedPassword(string encryptedPassword)
        {
            byte[] b;
            string decrypted;
            try
            {
                if (encryptedPassword == null)
                {
                    return null;
                }
                else
                {
                    b = Convert.FromBase64String(encryptedPassword);
                    decrypted = Encoding.ASCII.GetString(b);
                    return decrypted;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
