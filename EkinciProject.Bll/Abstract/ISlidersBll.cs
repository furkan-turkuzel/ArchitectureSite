using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Bll.Abstract
{
    public interface ISlidersBll
    {
        void Add(Sliders entity);
        void Delete(Sliders entity);
        void Update(Sliders entity);
        Sliders Get(Expression<Func<Sliders, bool>> filter);
        List<Sliders> GetAll(Expression<Func<Sliders, bool>> filter);
    }
}
