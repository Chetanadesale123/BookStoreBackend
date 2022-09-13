using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.OrderModel
{
    public class OrderDataModel
    {
        [Required]
        public int CartId { get; set; }

        [Required]
        public int AddressId { get; set; }

    }
}
