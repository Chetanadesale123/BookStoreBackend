using BusinessLayer.Interfaces;
using CommonLayer.BookModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL bookRL;

        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        public BookDataModel AddBook(BookDataModel bookdataModel)
        {
            try
            {
                return this.bookRL.AddBook(bookdataModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
