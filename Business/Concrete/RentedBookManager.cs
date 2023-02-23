using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Concrete.RentedBookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentedBookManager : IRentedBookService
    {
        private IRentedBookDal _rentedBookDal;
        private IUserDal _userDal;
        private IBookDal _bookDal;
        public RentedBookManager(IRentedBookDal rentedBookDal, IUserDal userDal, IBookDal bookDal)
        {
            _rentedBookDal = rentedBookDal;
            _userDal = userDal;
            _bookDal = bookDal;
        }

        public IResult Delivery(RentedBookDeliveryDto rentedBookDeliveryDto)
        {
            var isRentedBookExist = _rentedBookDal.Get(rb => rb.UserId == rentedBookDeliveryDto.UserId && rb.BookId == rentedBookDeliveryDto.BookId);
            if (isRentedBookExist is null)
            {
                return new ErrorResult("Kiralanan kitap bulunamadı!");
            }

            isRentedBookExist.DeliveryDate = DateTime.Now;
            _rentedBookDal.Update(isRentedBookExist);
            return new SuccessResult("Kitap başarıyla teslim edildi");
        }

        public IResult Rent(RentedBookRentDto rentedBookRentDto)
        {
            var isRenterUserExist = _userDal.Get(u => u.Id == rentedBookRentDto.UserId);
            if (isRenterUserExist is null)
            {
                return new ErrorResult("Kullanıcı bilgisi bulunamadı!");
            }

            var isRentedBookExist = _bookDal.Get(b => b.Id == rentedBookRentDto.BookId);
            if (isRentedBookExist is null)
            {
                return new ErrorResult("Kitap bulunamadı!");
            }
            else if (isRentedBookExist.Stock == 0)
            {
                return new ErrorResult("Üzgünüz kitap stoklarda kalmadı!");
            }

            var rentedBook = new RentedBook
            {
                UserId = rentedBookRentDto.UserId,
                BookId = rentedBookRentDto.BookId,
                RentalDate = DateTime.Now,
                DeliveryDate = null
            };
            _rentedBookDal.Add(rentedBook);
            isRentedBookExist.Stock--;
            _bookDal.Update(isRentedBookExist);

            return new SuccessResult("Kitabı başararıyla kiraladınız.");
        }
    }
}
