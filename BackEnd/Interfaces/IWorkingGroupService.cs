﻿using ComputerManage.Models;

namespace ComputerManage.Interfaces
{
    public interface IWorkingGroupService
    {
        Task<List<WorkingGroup>> GetAllAsync();
        Task<List<WorkingGroup>> GetDepartmentAllAsync(long departmentId);
        Task<WorkingGroup> GetGroupAsync(long id);
        Task<UserManagerResponse> CreateGroupAsync(WorkingGroup group);
        Task<UserManagerResponse> UpdateGroupAsync(long id, WorkingGroup group);
        Task<UserManagerResponse> DeleteGroupAsync(long id);
    }
}
