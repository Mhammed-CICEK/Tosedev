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
    public class OrderRepository : IOrderRepository 
    {
        private readonly AppDBContext _context;
        private DbSet<Order> _dbset;
        private DbSet<Adress> _dbsetAdress;
        private DbSet<Product> _dbsetProduct;
        public OrderRepository(AppDBContext context)
        {
            _context = context;
            _dbset = _context.Set<Order>();
            _dbsetAdress = _context.Set<Adress>();
            _dbsetProduct = _context.Set<Product>();
        }
        public bool Delete(Guid id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public List<Order> Get()
        {
            var order = _dbset.ToList();
            foreach (var item in order)
            {
                item.Adress = _dbsetAdress.Find(item.AdressId);
            }
            foreach (var item in order)
            {
                item.Product = _dbsetProduct.Find(item.ProductId);
            }
            
            return order;
        }

        public Order get(Guid id)
        {
            var order = _dbset.Find(id);
            order.Adress = _dbsetAdress.Find(order.AdressId);
            order.Product = _dbsetProduct.Find(order.ProductId);
            return order;
        }
        public bool Update(Order entity)
        {
            var adress = _dbsetAdress.Find(entity.AdressId);
            _context.Entry(adress).State = EntityState.Modified;
            if (_context.SaveChanges() <= 0)
                return false;
            var product = _dbsetProduct.Find(entity.ProductId);
            _context.Entry(product).State = EntityState.Modified;
            if (_context.SaveChanges() <= 0)
                return false;
            _context.Entry(entity).State = EntityState.Modified;
            if (_context.SaveChanges() <= 0)
                return false;
            return true;
        }

        public bool ChangeStatus(Guid id, string status)
        {
            var entity = _dbset.Find(id);
            entity.Status = status;
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public Guid Create(Order entity)
        {
            entity.Id = Guid.NewGuid();
            entity.Adress.AdressId = Guid.NewGuid();
            entity.Product.Id = Guid.NewGuid();
            _dbsetAdress.Add(entity.Adress);
            _context.SaveChanges();
            _dbsetProduct.Add(entity.Product);
            _context.SaveChanges();
            entity.AdressId = entity.Adress.AdressId;
            entity.ProductId = entity.Product.Id;
            _dbset.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public List<Order> orderGet(Guid id)
        {
            var order = _dbset.Where(x => x.Id.Equals(id)).ToList();
            foreach (var item in order)
            {
                item.Adress = _dbsetAdress.Find(item.AdressId);
            }
            foreach (var item in order)
            {
                item.Product = _dbsetProduct.Find(item.ProductId);
            }

            return order;    
        }

        

        
    }
}
