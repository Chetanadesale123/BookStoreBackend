using BusinessLayer.Interfaces;
using CommonLayer.BookModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
        [Authorize(Roles = Role.Admin)]
        [HttpPost("AddBook")]
        public IActionResult AddBook(BookDataModel bookdataModel)
        {
            try
            {
                var result = this.bookBL.AddBook(bookdataModel);
                if (result == null)
                {
                    return this.BadRequest(new { success = false, Message = "Book Add Failed " });
                }

                return this.Ok(new { success = true, Message = "Book Added Sucessfully", data = "Book Added :- " + result.BookName });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
