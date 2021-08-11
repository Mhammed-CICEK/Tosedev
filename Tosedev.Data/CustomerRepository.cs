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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDBContext _context;
        private DbSet<Customer> _dbset;
        private DbSet<Adress> _dbsetAdress;
        public CustomerRepository(AppDBContext context)
        {
            _context = context;
            _dbset = _context.Set<Customer>();
            _dbsetAdress = _context.Set<Adress>();
        }
        public bool Delete(Guid id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public List<Customer> Get()
        {
            var customer = _dbset.ToList();
            foreach (var item in customer)
            {
                item.Adress = _dbsetAdress.Find(item.AdressId);
            }

            return customer;
        }

        public Customer get(Guid id)
        {
            var customer = _dbset.Find(id);
            customer.Adress = _dbsetAdress.Find(customer.AdressId);
            return customer;
        }
        public bool Update(Customer entity)
        {
            var adress = _dbsetAdress.Find(entity.AdressId);
            _context.Entry(adress).State = EntityState.Modified;
            if (_context.SaveChanges() <= 0)
                return false;
            _context.Entry(entity).State = EntityState.Modified;
            if (_context.SaveChanges() <= 0)
                return false;
            return true;
        }


        public Guid Create(Customer entity)
        {
            _dbsetAdress.Add(entity.Adress);
            entity.AdressId = _dbsetAdress.Where(x => x.AdressId.Equals(entity.Adress.AdressLine)).FirstOrDefault().AdressId;
            _dbset.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public List<Customer> orderGet(Guid id)
        {
            var customer = _dbset.Where(x => x.Id.Equals(id)).ToList();
            foreach (var item in customer)
            {
                item.Adress = _dbsetAdress.Find(item.AdressId);
            }

            return customer;
        }
        public bool Validate(Guid id)
        {
            return _dbset.Find(id) != null;
        }


    }
}
