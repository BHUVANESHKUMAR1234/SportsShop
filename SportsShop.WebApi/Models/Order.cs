using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SportsShop.WebApi.Models
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }

       
       // [Column(TypeName = "DateTime")]
       public int? CustomerId { get; set; }
        public int? ItemNumber { get; set; }
        public String OrderAddress { get; set; }







        public DateTime OrderDate { get; set; }
        public virtual ICollection<Item> Item { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }

       
       




    }
}
