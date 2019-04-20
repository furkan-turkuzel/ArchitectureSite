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
    public class AboutService : IAboutBll
    {
        EfAboutDal _aboutDal = new EfAboutDal();
        public void Add(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void Delete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About Get(Expression<Func<About, bool>> filter)
        {
            return _aboutDal.Get(filter);
        }

        public List<About> GetAll(Expression<Func<About, bool>> filter = null)
        {
            return _aboutDal.GetAll(filter);
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
