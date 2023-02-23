using Entities.Dtos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Concrete.AuthorDtos
{
    public class AuthorCreateDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
