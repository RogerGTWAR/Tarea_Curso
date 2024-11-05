using SharedModels;

namespace Gestor_Api.Repository.IRepository
{
    public interface IIngresosoRepository : IRepository<Ingresos>
    {
        Task<Ingresos> UpdateAsync(Ingresos ingresos);
        Task<IEnumerable<Ingresos>> GetByEmployeeNumberAsync(int employeeNumber);
    }
}
