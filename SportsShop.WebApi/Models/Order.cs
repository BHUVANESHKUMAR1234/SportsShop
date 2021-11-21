using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SportsShop.WebApi.Models
{
    public class order
    {
        [Key]
        public int OrderNumber { get; set; }
        public int? CustomerId { get; set; }
        public int? ItemNumber { get; set; }

        
        public String OrderAddress { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
       
        public int? Total { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<Item> Item { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }

       
       




    }
}
