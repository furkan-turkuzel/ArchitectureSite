using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Bll.Abstract
{
    public interface IAdminBll
    {
        void Add(Admin entity);
        void Delete(Admin entity);
        void Update(Admin entity);
        Admin Get(Expression<Func<Admin, bool>> filter);
        List<Admin> GetAll(Expression<Func<Admin, bool>> filter = null);
    }
}
