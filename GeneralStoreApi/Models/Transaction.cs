using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStoreApi.Models
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(Product))]
        public string ProductSKU { get; set; }

        public virtual Product Product { get; set; }

        public int ItemCount { get; set; }

        public DateTime DateOfTransaction { get; set; }
    }
}