using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tosedev.Models;

namespace Tosedev.Core
{
    public interface ICustomerService:IService<Customer>
    {
        bool Update(Customer entity);
        bool Delete(Guid id);
        List<Customer> Get();
        Customer get(Guid id);
        Guid Create(Customer entity);
        bool Validete(Guid id);
    }
}
