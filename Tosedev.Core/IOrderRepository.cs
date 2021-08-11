using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tosedev.Models;

namespace Tosedev.Core
{
    public interface IOrderRepository:IRepository<Order>
    {
        bool Update(Order entity);
        bool Delete(Guid id);
        List<Order> Get();
        Order get(Guid id);
        Guid Create(Order entity);
        List<Order> orderGet(Guid id);
        bool ChangeStatus(Guid id, string status);
    }
}
