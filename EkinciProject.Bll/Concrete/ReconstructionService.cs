using EkinciProject.Bll.Abstract;
using EkinciProject.Dal.Concrete.Management;
using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Bll.Concrete
{
    public class ReconstructionService : IReconstructionBll
    {
        EfReconstructionDal _reconstructionDal = new EfReconstructionDal();

        public void Add(Reconstruction entity)
        {
            _reconstructionDal.Add(entity);
        }

        public void Delete(Reconstruction entity)
        {
            _reconstructionDal.Delete(entity);
        }

        public Reconstruction Get(Expression<Func<Reconstruction, bool>> filter)
        {
            return _reconstructionDal.Get(filter);
        }

        public List<Reconstruction> GetAll(Expression<Func<Reconstruction, bool>> filter = null)
        {
            return _reconstructionDal.GetAll(filter);
        }

        public void Update(Reconstruction entity)
        {
            _reconstructionDal.Update(entity);
        }
    }
}
