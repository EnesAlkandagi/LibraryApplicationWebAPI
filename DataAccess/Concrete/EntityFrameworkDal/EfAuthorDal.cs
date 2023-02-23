using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repository.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameworkDal
{
    internal class EfAuthorDal : EfEntityRepositoryBase<Author, BaseDbContext>, IAuthorDal
    {
        public EfAuthorDal(BaseDbContext context) : base(context)
        {

        }
    }
}
