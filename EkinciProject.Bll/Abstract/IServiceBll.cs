using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Bll.Abstract
{
    public interface IServiceBll
    {
        void Add(Service entity);
        void Delete(Service entity);
        void Update(Service entity);
        Service Get(Expression<Func<Service, bool>> filter);
        List<Service> GetAll(Expression<Func<Service, bool>> filter = null);
    }
}
