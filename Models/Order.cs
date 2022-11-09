using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KeyboArt.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserId { get;set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
        public ApplicationUser User { get; set; }

        // Relationships
        public List<OrderItem> OrderItems { get; set; }
    }
}
