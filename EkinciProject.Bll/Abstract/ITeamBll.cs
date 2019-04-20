using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Bll.Abstract
{
    public interface ITeamBll
    {
        void Add(Team entity);
        void Delete(Team entity);
        void Update(Team entity);
        Team Get(Expression<Func<Team, bool>> filter);
        List<Team> GetAll(Expression<Func<Team, bool>> filter = null);
    }
}
