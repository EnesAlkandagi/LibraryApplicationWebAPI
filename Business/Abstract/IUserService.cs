using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Concrete.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetByEmail(string email);
        User GetById(int id);
        IDataResult<User> RegisterAdmin(UserRegisterDto userRegisterDto);
    }
}
