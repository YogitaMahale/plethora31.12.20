using Microsoft.AspNetCore.Mvc.Rendering;
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
  public   class NewsServices : INewsServices
    {
        private readonly ApplicationDbContext _context;
        public NewsServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(News obj)
        {
            await _context.News.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int sectorid)
        {
            var objsector = GetById(sectorid);
            objsector.isdeleted = true;
            _context.News.Update(objsector); 
            await _context.SaveChangesAsync();
        }
        public IEnumerable<News> GetAll() => _context.News.Where(x => x.isdeleted == false).ToList();

        public News GetById(int sectorid) =>
            _context.News.Where(x => x.id == sectorid).FirstOrDefault();

        public async Task UpdateAsync(News obj)
        {
            _context.News.Update(obj);
            await _context.SaveChangesAsync();
        }

        
    }
} 