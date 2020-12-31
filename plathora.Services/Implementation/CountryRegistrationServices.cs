﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace plathora.Services.Implementation
{
    public class CountryRegistrationServices : ICountryRegistrationservices
    {
        private readonly ApplicationDbContext _context;
        public CountryRegistrationServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async  Task CreateAsync(CountryRegistration obj)
        {
            await _context.CountryRegistrations.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
 
        public async Task Delete(int countryid)
        {
            var country = GetById(countryid);
            country.isdeleted = true;
            _context.Update(country);             
            await _context.SaveChangesAsync();
        }
        public IEnumerable<CountryRegistration> GetAll() => _context.CountryRegistrations.Where(x => x.isdeleted == false).ToList();

        public CountryRegistration GetById(int affilateid) =>
            _context.CountryRegistrations.Where(x => x.id == affilateid).FirstOrDefault();

        public async Task UpdateAsync(CountryRegistration obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllCountry()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.countryname,
                Value = emp.id.ToString()
            });
        }
    }
}
