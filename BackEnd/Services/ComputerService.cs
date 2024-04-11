using ComputerManage.Data;
using ComputerManage.Interfaces;
using ComputerManage.Models;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace ComputerManage.Services
{
    public class ComputerService : IComputerService
    {
        private readonly ApplicationDbContext _context;

        public ComputerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserManagerResponse> CreateComputerAsync(Computer computer)
        {
            try
            {
                if (computer == null)
                {
                    return new UserManagerResponse
                    {
                        Message = "主机模型是空的",
                        IsSuccess = false
                    };
                }
                await _context.Computers.AddAsync(computer);
                await _context.SaveChangesAsync();
                return new UserManagerResponse
                {
                    Message = "主机信息创建成功",
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

        public async Task<UserManagerResponse> DeleteComputerAsync(long id)
        {
            try
            {
                var data = await _context.Computers.FindAsync(id);
                if (data is null)
                {
                    return new UserManagerResponse
                    {
                        Message = "主机信息不存在",
                        IsSuccess = false
                    };
                }
                _context.Computers.Remove(data);
                await _context.SaveChangesAsync();
                return new UserManagerResponse
                {
                    Message = "主机信息删除成功",
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

        public async Task<List<Computer>> GetAllAsync()
        {
            return await _context.Computers.ToListAsync();
        }

        public async Task<Computer> GetComputerAsync(long id)
        {
            var data = await _context.Computers.FindAsync(id);
            if (data == null) { return null; }
            return data;
        }


        public async Task<List<Computer>> GetDepartmentAllAsync(long departmentId)
        {
            var computers = await _context.Computers.ToListAsync();
            if (computers == null) return null;
            return computers.Where(computer => computer.DepartmentId == departmentId).ToList();
        }

        public async Task<UserManagerResponse> UpdateComputerAsync(long id, Computer computer)
        {
            try
            {
                if (id != computer.Id)
                {
                    return new UserManagerResponse
                    {
                        Message = "主机ID不匹配",
                        IsSuccess = false,
                    };
                }

                //_context.Entry(computer).State = EntityState.Modified;
                var result = _context.Computers.Update(computer);
                await _context.SaveChangesAsync();
                return new UserManagerResponse
                {
                    Message = "主机信息修改成功",
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
