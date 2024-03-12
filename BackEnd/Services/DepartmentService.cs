using ComputerManage.Data;
using ComputerManage.Interfaces;
using ComputerManage.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerManage.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserManagerResponse> CreateDepartmentAsync(Department department)
        {
            try
            {
                if (department == null)
                {
                    return new UserManagerResponse
                    {
                        Message = "Group model is null",
                        IsSuccess = false
                    };
                }
                await _context.Departments.AddAsync(department);
                await _context.SaveChangesAsync();
                return new UserManagerResponse
                {
                    Message = "Department Created successfully",
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new UserManagerResponse
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }

        public async Task<UserManagerResponse> DeleteDepartmentAsync(long id)
        {
            try
            {
                var data = await _context.Departments.FindAsync(id);
                if (data is null)
                {
                    return new UserManagerResponse
                    {
                        Message = "The department no longer exists",
                        IsSuccess = false
                    };
                }
                _context.Departments.Remove(data);
                await _context.SaveChangesAsync();
                return new UserManagerResponse
                {
                    Message = "Department deletion successful",
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new UserManagerResponse
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentAsync(long id)
        {
            var data = await _context.Departments.FindAsync(id);
            if (data == null) { return null; }
            return data;
        }

        public async Task<UserManagerResponse> UpdateDepartmentAsync(long id, Department department)
        {
            try
            {
                if (id != department.Id)
                {
                    return new UserManagerResponse
                    {
                        Message = "The department id does not match",
                        IsSuccess = false,
                    };
                }
                _context.Entry(department).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new UserManagerResponse
                {
                    Message = "Modified successfully",
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new UserManagerResponse
                {
                    Message = ex.Message,
                    IsSuccess = false,
                };
            }
        }
    }
}
