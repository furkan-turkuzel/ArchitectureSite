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
    public class MostAskedService : IMostAskedBll
    {
        EfMostAskedDal _mostAskedDal = new EfMostAskedDal();

        public void Add(MostAsked entity)
        {
            _mostAskedDal.Add(entity);
        }

        public void Delete(MostAsked entity)
        {
            _mostAskedDal.Delete(entity);
        }

        public MostAsked Get(Expression<Func<MostAsked, bool>> filter)
        {
            return _mostAskedDal.Get(filter);
        }

        public List<MostAsked> GetAll(Expression<Func<MostAsked, bool>> filter = null)
        {
            return _mostAskedDal.GetAll(filter);
        }

        public void Update(MostAsked entity)
        {
            _mostAskedDal.Update(entity);
        }
    }
}
