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
    public class ContactService : IContactBll
    {
        EfContactDal _contactDal = new EfContactDal();

        public Contact Get()
        {
            return _contactDal.Get(x=>x.Id == 1);
        }
        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
