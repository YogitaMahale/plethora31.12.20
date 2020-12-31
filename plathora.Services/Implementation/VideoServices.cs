using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace plathora.Services.Implementation
{
   public class VideoServices: IVideoServices
    {
        private readonly ApplicationDbContext _context;
        public VideoServices(ApplicationDbContext context)
        {
            _context = context;
        }




        public async Task CreateAsync(Videos obj)
        {
            await _context.videos.AddAsync(obj);
            await _context.SaveChangesAsync();
        }



        public async Task Delete(int id)
        {
            var obj = GetById(id);
            obj.isdeleted = true;
            _context.videos.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Videos> GetAll() => _context.videos.Where(x => x.isdeleted == false).ToList();




        public Videos GetById(int id) =>
            _context.videos.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(Videos obj)
        {
            _context.videos.Update(obj);
            await _context.SaveChangesAsync();
        }



    }
}
