using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Dtos.Concrete.UserDtos;
using Core.Utilities.Security.Hashing;
using Entities.Enums;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IUserRoleDal _userRoleDal;
        public UserManager(IUserDal userDal, IUserRoleDal userRoleDal)
        {
            _userDal = userDal;
            _userRoleDal = userRoleDal;
        }
        public User GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _userDal.Get(u => u.Id == id);
        }

        public IDataResult<User> RegisterAdmin(UserRegisterDto userRegisterDto)
        {
            byte[] passwordHash, passwordSalt;

            var existEmail = _userDal.Get(u => u.Email == userRegisterDto.Email);

            if (existEmail is not null)
            {
                return new ErrorDataResult<User>("Bu mail adresi kullanılmaktadır.");
            }
            if (!userRegisterDto.Email.Contains("@") || !userRegisterDto.Email.EndsWith(".com")) //email formatını denemek için yaptım best practise değildir.
            {
                return new ErrorDataResult<User>("Geçerli bir mail adresi giriniz lütfen.");
            }

            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            _userDal.Add(user);

            var savedUser = GetByEmail(userRegisterDto.Email);
            var userClaim = new UserRole
            {
                UserId = savedUser.Id,
                RoleId = (int)EnmUserRole.ADMIN
            };

            _userRoleDal.Add(userClaim);

            return new SuccessDataResult<User>(user,"Admin başarıyla oluşturuldu.");
        }
    }
}
