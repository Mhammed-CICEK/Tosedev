using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tosedev.Models;

namespace Tosedev.Core
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        bool Update(Customer entity);
        bool Delete(Guid id);
        List<Customer> Get();
        Customer get(Guid id);
        Guid Create(Customer entity);
        bool Validate(Guid id);
    }
}
