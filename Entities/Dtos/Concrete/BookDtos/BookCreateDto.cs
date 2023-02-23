using Entities.Dtos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.BookDtos
{
    public class BookCreateDto : IDto
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int PageNumber { get; set; }
        public int Stock { get; set; }
        public string Detail { get; set; }
    }
}
