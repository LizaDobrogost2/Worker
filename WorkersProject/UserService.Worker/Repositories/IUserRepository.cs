using Shared.Contracts.Models;

public interface IUserRepository
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    // Можем потом добавить: GetByIdAsync, UpdateAsync, DeleteAsync и т.п.
}
