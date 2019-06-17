using Image.Server.Context;
using Image.Server.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Image.Server.Services
{
    public class HeroesRepository : IHeroesRepository
    {
        private  ProductImageDbContext _context;
        private readonly  IHttpClientFactory _httpClientFactory;

        public HeroesRepository(
            ProductImageDbContext context, 
            IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        //Per api instructions don't use .AddAsync()
        public void AddHero(Hero HeroToAdd)
        {
            if (HeroToAdd == null)
                throw new ArgumentNullException(nameof(HeroToAdd));

            _context.Add(HeroToAdd);
        }

        public async Task<Hero> GetHeroAsync(int id)
        {
            return await _context.Heroes
                .Where(h => h.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Hero>> GetHeroesAsync()
        {
            return await _context.Heroes
                .ToListAsync();
        }

        /*
        public async Task<bool> UpdateHero(Hero dbHero, Hero hero)
        {
            
        }
        */

        private bool HeroExists(int id)
        {
            return _context.Heroes.Any(e => e.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

    }
}
