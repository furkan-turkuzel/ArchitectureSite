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
    public class AdminService : IAdminBll
    {
        EfAdminDal _adminDal = new EfAdminDal();

        public void Add(Admin entity)
        {
            _adminDal.Add(entity);
        }

        public void Delete(Admin entity)
        {
            _adminDal.Delete(entity);
        }

        public Admin Get(Expression<Func<Admin, bool>> filter)
        {
            return _adminDal.Get(filter);
        }

        public List<Admin> GetAll(Expression<Func<Admin, bool>> filter = null)
        {
            return _adminDal.GetAll(filter);
        }

        public void Update(Admin entity)
        {
            _adminDal.Update(entity);
        }
    }
}
