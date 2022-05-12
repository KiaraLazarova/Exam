using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AreaContext : IDB<Area, int>
    {
        private readonly ApplicationDBContext _dbContext;

        public AreaContext(ApplicationDBContext dbContext)
        {
            _dbContext=dbContext;
        }

        public void Create(Area item)
        {
            _dbContext.Areas.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            _dbContext.Areas.Remove(Read(key));
            _dbContext.SaveChanges();
        }

        public Area Read(int key)
        {
            return _dbContext.Areas.Find(key);
        }

        public IEnumerable<Area> ReadAll()
        {
            return _dbContext.Areas.ToList();
        }

        public void Update(Area item)
        {
            _dbContext.Areas.Update(item);
            _dbContext.SaveChanges();
        }
    }
}