using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class InterestContext : IDB<Interest, int>
    {
        private readonly ApplicationDBContext _dbContext;

        public InterestContext(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Interest item)
        {
            _dbContext.Interests.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            _dbContext.Interests.Remove(Read(key));
            _dbContext.SaveChanges();
        }

        public Interest Read(int key)
        {
            return _dbContext.Interests.Find(key);
        }

        public IEnumerable<Interest> ReadAll()
        {
            return _dbContext.Interests.ToList();
        }

        public void Update(Interest item)
        {
            _dbContext.Interests.Update(item);
            _dbContext.SaveChanges();
        }
    }
}