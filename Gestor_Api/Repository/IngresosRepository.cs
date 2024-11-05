using Gestor_Api.Data;
using Gestor_Api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Gestor_Api.Repository
{
    public class IngresosRepository : Repository<Ingresos>, IIngresosoRepository
    {
        private readonly Context _context;

        public IngresosRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<Ingresos> UpdateAsync(Ingresos ingresos)
        {
            _context.Entry(ingresos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ingresos;
        }

        public async Task<IEnumerable<Ingresos>> GetByEmployeeNumberAsync(int employeeNumber)
        {
            return await _context.EmpleadosIngresos.Where(i => i.Ingresos_Id == employeeNumber).ToListAsync();
        }
    }
}
