using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tosedev.Core;
using Tosedev.Models;

namespace Tosedev.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDBContext _context;
        private DbSet<TEntity> _dbset;

        public Repository(AppDBContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }
        public bool Delete(Guid id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public List<TEntity> Get()
        {
            
            return _dbset.ToList();
        }

        public TEntity get(Guid id)
        {

            return _dbset.Find(id);
        }
        public bool Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
