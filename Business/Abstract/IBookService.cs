using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Concrete.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        public IResult Create(BookCreateDto bookCreateDto);
        public IResult Delete(int id);
        public IDataResult<List<Book>> GetList(BookFilterDto bookFilterDto);
    }
}
