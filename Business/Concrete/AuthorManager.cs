using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Concrete.AuthorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private IAuthorDal _authorDal;
        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public IResult Create(AuthorCreateDto authorCreateDto)
        {
            if (string.IsNullOrEmpty(authorCreateDto.FirstName) || string.IsNullOrEmpty(authorCreateDto.LastName))
            {
                return new ErrorResult("Yazar ismi ve soyismi boş bırakılamaz!");
            }

            var isAuthorExist = _authorDal.Get(a => a.FirstName == authorCreateDto.FirstName && a.LastName == authorCreateDto.LastName);
            if (isAuthorExist != null)
            {
                return new ErrorResult("Aynı isimde yazar mevcut!");
            }

            var author = new Author
            {
                FirstName = authorCreateDto.FirstName,
                LastName = authorCreateDto.LastName
            };
            _authorDal.Add(author);
            return new SuccessResult("Yazar başarıyla eklendi.");
        }

        public IResult Delete(int id)
        {
            var isAuthorExist = _authorDal.Get(a => a.Id == id);
            if (isAuthorExist is null)
            {
                return new ErrorResult("Yazar bulunumadı!");
            }

            _authorDal.Delete(isAuthorExist);
            return new SuccessResult("Yazar başarıyla silindi.");
        }
    }
}
