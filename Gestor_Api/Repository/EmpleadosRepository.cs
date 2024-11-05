using Gestor_Api.Data;
using Gestor_Api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Gestor_Api.Repository
{
    public class EmpleadosRepository : Repository<EmpleadoDatos>, IEmpleadosRepository
    {
        private readonly Context _context;

        public EmpleadosRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<EmpleadoDatos> UpdateAsync(EmpleadoDatos entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}