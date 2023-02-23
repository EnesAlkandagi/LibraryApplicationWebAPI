using Business.Abstract;
using Core.Utilities.JWT;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Concrete.UserDtos;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserDal _userDal;
        private IUserService _userService;
        private IUserRoleDal _userRoleDal;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserDal userDal, IUserService userService, IUserRoleDal userRoleDal, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _userService = userService;
            _userRoleDal = userRoleDal;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> Login(UserLoginDto userLoginDto)
        {
            var isUserExist = _userDal.Get(x => x.Email.Equals(userLoginDto.Email));
            if (isUserExist is null)
            {
                return new ErrorDataResult<AccessToken>("Kullanıcı bulunamadı. Lütfen kayıt olunuz.");
            }

            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, isUserExist.PasswordHash, isUserExist.PasswordSalt))
            {
                return new ErrorDataResult<AccessToken>("Hatalı parola!");
            }

            var claims = _userDal.GetClaims(isUserExist);
            var accessToken = _tokenHelper.CreateToken(isUserExist, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto)
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

            var savedUser = _userService.GetByEmail(userRegisterDto.Email);
            var userClaim = new UserRole
            {
                UserId = savedUser.Id,
                RoleId = (int) EnmUserRole.USER
            };

            _userRoleDal.Add(userClaim);

            return new SuccessDataResult<User>(user,"Kullanıcı başarıyla oluşturuldu.");
        }
    }
}
