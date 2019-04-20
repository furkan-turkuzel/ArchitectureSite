using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Bll.Abstract
{
    public interface INewsBll
    {
        void Add(News entity);
        void Delete(News entity);
        void Update(News entity);
        News Get(Expression<Func<News, bool>> filter);
        List<News> GetAll(Expression<Func<News, bool>> filter = null);
    }
}
