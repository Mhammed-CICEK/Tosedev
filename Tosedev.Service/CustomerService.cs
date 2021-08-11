using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tosedev.Core;
using Tosedev.Models;

namespace Tosedev.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public List<Customer> Get()
        {
            return _repository.Get();
        }

        public Customer get(Guid id)
        {
            return _repository.get(id);
        }

        public bool Update(Customer entity)
        {
            return _repository.Update(entity);
        }
        public Guid Create(Customer entity)
        {
            return _repository.Create(entity);
        }

        public bool Validete(Guid id)
        {
            return _repository.Validate(id);
        }
    }
}
