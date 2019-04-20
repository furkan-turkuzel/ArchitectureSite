using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Bll.Abstract
{
    public interface IMostAskedBll
    {
        void Add(MostAsked entity);
        void Delete(MostAsked entity);
        void Update(MostAsked entity);
        MostAsked Get(Expression<Func<MostAsked, bool>> filter);
        List<MostAsked> GetAll(Expression<Func<MostAsked, bool>> filter = null);
    }
}
