using Entities.Concrete;

namespace Core.Utilities.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, List<Role> userRole);

}