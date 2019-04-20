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
    public class TeamService : ITeamBll
    {
        EfTeamDal _teamDal = new EfTeamDal();
        public void Add(Team entity)
        {
            _teamDal.Add(entity);
        }

        public void Delete(Team entity)
        {
            _teamDal.Delete(entity);
        }

        public Team Get(Expression<Func<Team, bool>> filter)
        {
            return _teamDal.Get(filter);
        }

        public List<Team> GetAll(Expression<Func<Team, bool>> filter = null)
        {
            return _teamDal.GetAll(filter);
        }

        public void Update(Team entity)
        {
            _teamDal.Update(entity);
        }
    }
}
