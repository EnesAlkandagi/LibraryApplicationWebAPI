using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("author_id")]
        public int AuthorId { get; set; }
        [Column("page_number")]
        public int PageNumber { get; set; }
        [Column("stock")]
        public int Stock { get; set; }
        [Column("detail")]
        public string Detail { get; set; }
        public Author Author { get; set; }
        public ICollection<RentedBook> Users { get; set; }
    }
}
