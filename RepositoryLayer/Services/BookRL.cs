using CommonLayer.BookModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class BookRL : IBookRL
    {
        private readonly string connectionString;
        public BookRL(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("BookStoreConnection");
        }
        public BookDataModel AddBook(BookDataModel bookdataModel)
        {
            SqlConnection sqlconnection = new SqlConnection(this.connectionString);
            try
            {
                {
                    sqlconnection.Open();

                    SqlCommand cmd = new SqlCommand("SPAddBook", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName ", bookdataModel.BookName);
                    cmd.Parameters.AddWithValue("@Author", bookdataModel.Author);
                    cmd.Parameters.AddWithValue("@Description ", bookdataModel.Description);
                    cmd.Parameters.AddWithValue("@Quantity", bookdataModel.Quantity);
                    cmd.Parameters.AddWithValue("@Price", bookdataModel.Price);
                    cmd.Parameters.AddWithValue("@DiscountPrice ", bookdataModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@TotalRating ", bookdataModel.TotalRating);
                    cmd.Parameters.AddWithValue("@RatingCount", bookdataModel.RatingCount);
                    cmd.Parameters.AddWithValue("@BookImg", bookdataModel.BookImg);

                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return bookdataModel;
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
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}
