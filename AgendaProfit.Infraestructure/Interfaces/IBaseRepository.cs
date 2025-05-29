namespace AgendaProfit.Infraestructure.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T> ObterPorIdAsync(int id);
    Task<T> ObterPorIdDetalhadoAsync(int id);
    Task<IEnumerable<T>> ObterTudoAsync();
    Task<int> AdicionarAsync(T entity);
    Task AlterarAsync(T entity);
    Task RemoverAsync(int id);
    Task<bool> VerificarSeExiste(int id);
}
