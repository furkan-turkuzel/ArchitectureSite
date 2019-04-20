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
    public class VisitorService : IVisitorBll
    {
        EfVisitorDal _visitorDal = new EfVisitorDal();
        public void Add(Visitor entity)
        {
            _visitorDal.Add(entity);
        }

        public void Delete(Visitor entity)
        {
            _visitorDal.Delete(entity);
        }

        public Visitor Get(Expression<Func<Visitor, bool>> filter)
        {
            return _visitorDal.Get(filter);
        }

        public List<Visitor> GetAll(Expression<Func<Visitor, bool>> filter = null)
        {
            return _visitorDal.GetAll(filter);
        }

        public void Update(Visitor entity)
        {
            _visitorDal.Update(entity);
        }
    }
}
