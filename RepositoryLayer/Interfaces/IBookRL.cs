using CommonLayer.BookModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IBookRL
    {
        public BookDataModel AddBook(BookDataModel bookdataModel);
    }
}
