using Core.Utilities.Results;
using Entities.Dtos.Concrete.RentedBookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentedBookService
    {
        public IResult Rent(RentedBookRentDto rentedBookRentDto);
        public IResult Delivery(RentedBookDeliveryDto rentedBookDeliveryDto);
    }
}
