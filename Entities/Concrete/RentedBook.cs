using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RentedBook : IEntity
    {
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("rental_date")]
        public DateTime RentalDate { get; set; }
        [Column("delivery_date")]
        public DateTime? DeliveryDate { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }

    }
}
