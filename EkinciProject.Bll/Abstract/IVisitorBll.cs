using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Bll.Abstract
{
    public interface IVisitorBll
    {
        void Add(Visitor entity);
        void Delete(Visitor entity);
        void Update(Visitor entity);
        Visitor Get(Expression<Func<Visitor, bool>> filter);
        List<Visitor> GetAll(Expression<Func<Visitor, bool>> filter = null);
    }
}
