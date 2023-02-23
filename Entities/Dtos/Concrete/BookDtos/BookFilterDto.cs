using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.BookDtos
{
    public class BookFilterDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int AuthorId { get; set; }
        public int PageNumber { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            var queryString = string.Empty;
            queryString += $"?Id={Id}&Name={Name}&AuthorId={AuthorId}&PageNumber={PageNumber}&Stock={Stock}";
            return queryString;
        }
    }
}
