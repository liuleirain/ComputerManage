using ComputerManage.Models;

namespace ComputerManage.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllAsync();
        Task<Department> GetDepartmentAsync(long id);
        Task<UserManagerResponse> CreateDepartmentAsync(Department department);
        Task<UserManagerResponse> UpdateDepartmentAsync(long id, Department department);
        Task<UserManagerResponse> DeleteDepartmentAsync(long id);
    }
}
