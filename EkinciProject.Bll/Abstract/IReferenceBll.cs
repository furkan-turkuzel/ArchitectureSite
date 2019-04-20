using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Bll.Abstract
{
    public interface IReferenceBll
    {
        void Add(Reference entity);
        void Delete(Reference entity);
        void Update(Reference entity);
        Reference Get(Expression<Func<Reference, bool>> filter);
        List<Reference> GetAll(Expression<Func<Reference, bool>> filter = null);
    }
}
