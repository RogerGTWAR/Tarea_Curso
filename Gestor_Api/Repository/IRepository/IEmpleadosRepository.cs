using SharedModels;

namespace Gestor_Api.Repository.IRepository
{
    public interface IEmpleadosRepository : IRepository<EmpleadoDatos>
    {
        Task<EmpleadoDatos> UpdateAsync(EmpleadoDatos entity);
    }
}
