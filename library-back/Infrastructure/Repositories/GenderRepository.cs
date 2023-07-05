using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Models;
using Library.Infrastructure.Context;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly LibraryContext _context;

        public GenderRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Gender>> GetAllAsync()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<Gender> GetByIdAsync(int id)
        {
            return await _context!.Genders!.FirstOrDefaultAsync(e => e.Id == id) ?? null;
        }

        public async Task AddAsync(Gender entity)
        {
            await _context.Genders.AddAsync(entity);
        }

        public void Update(Gender entity)
        {
            _context.Genders.Update(entity);
        }

        public void Delete(Gender entity)
        {
            _context.Genders.Remove(entity);
        }
    }
}