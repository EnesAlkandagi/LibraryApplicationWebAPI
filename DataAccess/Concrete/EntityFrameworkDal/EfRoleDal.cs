using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repository.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkDal
{
    internal class EfRoleDal : EfEntityRepositoryBase<Role, BaseDbContext>, IRoleDal
    {
        public EfRoleDal(BaseDbContext context) : base(context)
        {
        }
    }
}
