using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Bll.Abstract
{
    public interface IAboutBll
    {
        void Add(About entity);
        void Delete(About entity);
        void Update(About entity);
        About Get(Expression<Func<About,bool>> filter);
        List<About> GetAll(Expression<Func<About, bool>> filter = null);
    }
}
