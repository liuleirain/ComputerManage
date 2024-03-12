using ComputerManage.Data;
using ComputerManage.Interfaces;
using ComputerManage.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerManage.Services
{
    public class WorkingGroupService : IWorkingGroupService
    {
        private readonly ApplicationDbContext _context;

        public WorkingGroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserManagerResponse> CreateGroupAsync(WorkingGroup group)
        {
            try
            {
                if (group == null)
                {
                    return new UserManagerResponse
                    {
                        Message = "Group model is null",
                        IsSuccess = false
                    };
                }
                await _context.WorkingGroups.AddAsync(group);
                await _context.SaveChangesAsync();
                return new UserManagerResponse
                {
                    Message = "Group Created successfully",
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

        public async Task<UserManagerResponse> DeleteGroupAsync(long id)
        {
            try
            {
                var data = await _context.WorkingGroups.FindAsync(id);
                if (data is null)
                {
                    return new UserManagerResponse
                    {
                        Message = "The Working group no longer exists",
                        IsSuccess = false
                    };
                }
                _context.WorkingGroups.Remove(data);
                await _context.SaveChangesAsync();
                return new UserManagerResponse
                {
                    Message = "Group deletion successful",
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

        public async Task<List<WorkingGroup>> GetAllAsync()
        {
            return await _context.WorkingGroups.ToListAsync();
        }

        public async Task<WorkingGroup> GetGroupAsync(long id)
        {
            var data = await _context.WorkingGroups.FindAsync(id);
            if (data == null) { return null; }
            return data;
        }

        public async Task<UserManagerResponse> UpdateGroupAsync(long id, WorkingGroup group)
        {
            try
            {
                if (id != group.Id)
                {
                    return new UserManagerResponse
                    {
                        Message = "The group id does not match",
                        IsSuccess = false,
                    };
                }
                _context.Entry(group).State = EntityState.Modified;
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
