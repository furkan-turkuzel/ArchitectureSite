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
    public class SlidersService : ISlidersBll
    {
        EfSlidersDal _slidersDal = new EfSlidersDal();

        public void Add(Sliders entity)
        {
            _slidersDal.Add(entity);
        }

        public void Delete(Sliders entity)
        {
            _slidersDal.Delete(entity);
        }

        public Sliders Get(Expression<Func<Sliders, bool>> filter)
        {
            return _slidersDal.Get(filter);
        }

        public List<Sliders> GetAll(Expression<Func<Sliders, bool>> filter = null)
        {
            return _slidersDal.GetAll(filter);
        }

        public void Update(Sliders entity)
        {
            _slidersDal.Update(entity);
        }
    }
}
