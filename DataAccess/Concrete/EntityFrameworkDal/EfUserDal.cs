using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repository.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkDal
{
    internal class EfUserDal : EfEntityRepositoryBase<User, BaseDbContext>, IUserDal
    {
        public EfUserDal(BaseDbContext context) : base(context)
        {
        }

        public List<Role> GetClaims(User user)
        {
            if (user != null)
            {

                var result = from operationClaim in Context.Roles
                             join userOperationClaim in Context.UserRoles
                                 on operationClaim.Id equals userOperationClaim.RoleId
                             where userOperationClaim.UserId == user.Id
                             select new Role { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }

            return null;
        }
    }
}
