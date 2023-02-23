using Business.Abstract;
using Core.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Concrete.BookDtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;
        private IAuthorDal _authorDal;
        public BookManager(IBookDal bookDal, IAuthorDal authorDal)
        {
            _bookDal = bookDal;
            _authorDal = authorDal;
        }

        public IResult Create(BookCreateDto bookCreateDto)
        {
            if (bookCreateDto.PageNumber <= 0)
            {
                return new ErrorResult("Sayfa sayısı 0'dan büyük olmalıdır!");
            }
            if (bookCreateDto.Stock <= 0)
            {
                return new ErrorResult("Stok sayısı 0'dan büyük olmalıdır!");
            }
            if (string.IsNullOrEmpty(bookCreateDto.Name))
            {
                return new ErrorResult("Lütfen kitap ismini giriniz!");
            }
            var isAuthorExist = _authorDal.Get(a => a.Id == bookCreateDto.AuthorId);
            if (isAuthorExist == null)
            {
                return new ErrorResult("Yazar bulunamadı!");
            }

            var book = new Book
            {
                Name = bookCreateDto.Name,
                AuthorId = bookCreateDto.AuthorId,
                PageNumber = bookCreateDto.PageNumber,
                Detail = bookCreateDto.Detail,
                Stock = bookCreateDto.Stock,
            };
            _bookDal.Add(book);
            return new SuccessResult("Kitap başarıyla eklendi");
        }

        public IResult Delete(int id)
        {
            var isBookExist = _bookDal.Get(b => b.Id == id);
            if (isBookExist is null)
            {
                return new ErrorResult("Kitap Bulunamadı");
            }

            _bookDal.Delete(isBookExist);
            return new SuccessResult("Kitap başarıyla silindi");
        }

        public IDataResult<List<Book>> GetList(BookFilterDto bookFilterDto)
        {
            var predicate = PredicateBuilder.True<Book>();

            if (bookFilterDto.Id > 0)
            {
                predicate.And(b => b.Id == bookFilterDto.Id);
            }
            if (!string.IsNullOrEmpty(bookFilterDto.Name))
            {
                predicate.And(b => b.Name.Contains(bookFilterDto.Name));
            }
            if (bookFilterDto.PageNumber > 0)
            {
                predicate.And(b => b.PageNumber == bookFilterDto.PageNumber);
            }
            if (bookFilterDto.Stock > 0)
            {
                predicate.And(b => b.Stock == bookFilterDto.Stock);
            }
            if (bookFilterDto.AuthorId > 0)
            {
                predicate.And(b => b.AuthorId == bookFilterDto.AuthorId);
            }
            
            var books = _bookDal.GetAll(predicate);
            return new SuccessDataResult<List<Book>>(books);
        }
    }
}
