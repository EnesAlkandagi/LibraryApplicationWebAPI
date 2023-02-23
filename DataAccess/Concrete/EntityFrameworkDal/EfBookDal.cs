﻿using DataAccess.Abstract;
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
    internal class EfBookDal : EfEntityRepositoryBase<Book, BaseDbContext>, IBookDal
    {
        public EfBookDal(BaseDbContext context) : base(context)
        {
        }
    }
}
