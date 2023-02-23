using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.RentedBookDtos
{
    public class RentedBookDeliveryDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
