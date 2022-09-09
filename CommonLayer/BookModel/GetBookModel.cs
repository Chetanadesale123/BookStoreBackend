using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.BookModel
{
    public class GetBookModel
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double DiscountPrice { get; set; }

        public float TotalRating { get; set; }

        public int RatingCount { get; set; }

        public string BookImg { get; set; }
    }
}
