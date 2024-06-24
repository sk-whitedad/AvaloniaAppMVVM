using AvaloniaDB.Interfaces;
using AvaloniaDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AvaloniaDB.Implementation
{
    public class CompanyRepository : IBaseRepository<Company>
    {
        private readonly ApplicationDbContext _dbContext;
        public CompanyRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task Create(Company entity)
        {
            await _dbContext.Companies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Company entity)
        {
            _dbContext.Companies.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Company> GetAll()
        {
            return _dbContext.Companies;
        }

        public async Task<Company> Update(Company entity)
        {
            var company = _dbContext.Companies.FirstOrDefault(x => x.Id == entity.Id);
            if (company != null)
            {
                company.Name = entity.Name;
                company.Address = entity.Address;
                company.PhoneNumber = entity.PhoneNumber;
                company.Description = entity.Description;
                await _dbContext.SaveChangesAsync();
            }
            return entity;
        }
    }
}
