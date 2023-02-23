using Core.Utilities.Results;
using Entities.Dtos.Concrete.AuthorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        public IResult Create(AuthorCreateDto authorCreateDto);
        public IResult Delete(int id);
    }
}
