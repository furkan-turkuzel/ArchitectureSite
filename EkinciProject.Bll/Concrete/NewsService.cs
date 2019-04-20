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
    public class NewsService : INewsBll
    {
        EfNewsDal _newsDal = new EfNewsDal();
        public void Add(News entity)
        {
            _newsDal.Add(entity);
        }

        public void Delete(News entity)
        {
            _newsDal.Delete(entity);
        }

        public News Get(Expression<Func<News, bool>> filter)
        {
            return _newsDal.Get(filter);
        }

        public List<News> GetAll(Expression<Func<News, bool>> filter = null)
        {
            return _newsDal.GetAll(filter);
        }

        public void Update(News entity)
        {
            _newsDal.Update(entity);
        }
    }
}
