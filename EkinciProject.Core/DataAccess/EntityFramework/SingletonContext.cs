using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Core.DataAccess.EntityFramework
{
    public class SingletonContext<TContext> where TContext : DbContext,new()
    {
        private static TContext _context;

        public static TContext Context
        {
            get
            {
                if (_context == null)
                    _context = new TContext();
                return _context;
            }
        }
    }
}
