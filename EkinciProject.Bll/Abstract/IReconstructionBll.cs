using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Bll.Abstract
{
    public interface IReconstructionBll
    {
        void Add(Reconstruction entity);
        void Delete(Reconstruction entity);
        void Update(Reconstruction entity);
        Reconstruction Get(Expression<Func<Reconstruction, bool>> filter);
        List<Reconstruction> GetAll(Expression<Func<Reconstruction, bool>> filter);
    }
}
