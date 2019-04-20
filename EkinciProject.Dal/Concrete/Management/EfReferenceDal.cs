using EkinciProject.Core.DataAccess.EntityFramework;
using EkinciProject.Dal.Abstract;
using EkinciProject.Dal.Concrete.DBContext;
using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Dal.Concrete.Management
{
    public class EfReferenceDal : EFEntityRepositoryBase<EkinciDbContext, Reference>, IReferenceDal
    {
    }
}
