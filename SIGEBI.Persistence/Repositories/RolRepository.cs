using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Interfaces;
using SIGEBI.Persistence.Context;

namespace SIGEBI.Persistence.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly AppDbContext _context;

        public RolRepository(AppDbContext context) => _context = context;

        public async Task<Rol?> GetByIdAsync(int id) =>
            await _context.Roles.FindAsync(id);

        public async Task<IEnumerable<Rol>> GetAllAsync() =>
            await _context.Roles.ToListAsync();

        public async Task<Rol> AddAsync(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task UpdateAsync(Rol rol)
        {
            _context.Roles.Update(rol);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rol = await GetByIdAsync(id);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }
    }
}