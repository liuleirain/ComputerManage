using ComputerManage.Models;

namespace ComputerManage.Interfaces
{
    public interface IComputerService
    {
        Task<List<Computer>> GetAllAsync();
        Task<List<Computer>> GetDepartmentAllAsync(long departmentId);
        Task<Computer> GetComputerAsync(long id);
        Task<UserManagerResponse> CreateComputerAsync(Computer computer);
        Task<UserManagerResponse> UpdateComputerAsync(long id, Computer computer);
        Task<UserManagerResponse> DeleteComputerAsync(long id);
    }
}
