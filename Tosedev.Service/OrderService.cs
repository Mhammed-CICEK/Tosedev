using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tosedev.Core;
using Tosedev.Models;

namespace Tosedev.Service
{
    public class OrderService : IOrderService

    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public List<Order> Get()
        {
            return _repository.Get();
        }

        public Order get(Guid id)
        {
            return _repository.get(id);
        }

        public bool Update(Order entity)
        {
            return _repository.Update(entity);
        }
        public bool ChangeStatus(Guid id, string status)
        {
            return _repository.ChangeStatus(id, status);
        }

        public Guid Create(Order entity)
        {
            return _repository.Create(entity);
        }

        public List<Order> orderGet(Guid id)
        {
            return _repository.orderGet(id);
        }
    }
}
