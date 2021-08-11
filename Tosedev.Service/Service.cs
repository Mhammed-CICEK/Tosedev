using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tosedev.Core;

namespace Tosedev.Service
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        //private readonly IRepository<TEntity> _repository;
        //public Service(IRepository<TEntity> repository)
        //{
        //    _repository = repository;
        //}
        //public bool Delete(Guid id)
        //{
        //    return _repository.Delete(id);
        //}

        //public List<TEntity> Get()
        //{
        //    return _repository.Get();
        //}

        //public TEntity get(Guid id)
        //{
        //    return _repository.get(id);
        //}

        //public bool Update(TEntity entity)
        //{
        //    return _repository.Update(entity);
        //}
    }
}
