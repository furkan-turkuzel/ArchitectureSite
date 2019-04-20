using EkinciProject.Bll.Abstract;
using EkinciProject.Dal.Abstract;
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
    public class ReferenceService : IReferenceBll
    {
        EfReferenceDal _referenceDal = new EfReferenceDal();
        public void Add(Reference entity)
        {
            try
            {
                _referenceDal.Add(entity);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public void Delete(Reference entity)
        {
            _referenceDal.Delete(entity);
        }

        public Reference Get(Expression<Func<Reference, bool>> filter)
        {
            return _referenceDal.Get(filter);
        }

        public List<Reference> GetAll(Expression<Func<Reference, bool>> filter = null)
        {
            return _referenceDal.GetAll(filter);
        }

        public void Update(Reference entity)
        {
            _referenceDal.Update(entity);
        }
    }
}
