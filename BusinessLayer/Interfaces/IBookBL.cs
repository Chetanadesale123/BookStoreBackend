using CommonLayer.BookModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IBookBL
    {
        public BookDataModel AddBook(BookDataModel bookdataModel);
    }
}
