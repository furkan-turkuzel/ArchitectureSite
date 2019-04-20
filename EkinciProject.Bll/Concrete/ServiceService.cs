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
    public class ServiceService : IServiceBll
    {
        EfServiceDal _serviceDal = new EfServiceDal();
        public void Add(Service entity)
        {
            _serviceDal.Add(entity);
        }

        public void Delete(Service entity)
        {
            _serviceDal.Delete(entity);
        }

        public Service Get(Expression<Func<Service, bool>> filter)
        {
            return _serviceDal.Get(filter);
        }

        public List<Service> GetAll(Expression<Func<Service, bool>> filter = null)
        {
            return _serviceDal.GetAll(filter);
        }

        public void Update(Service entity)
        {
            _serviceDal.Update(entity);
        }
    }
}
