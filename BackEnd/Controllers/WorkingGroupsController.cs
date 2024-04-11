using ComputerManage.Interfaces;
using ComputerManage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace ComputerManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="SuperAdministrator,Administrator")]
    public class WorkingGroupsController : ControllerBase
    {
        private readonly IWorkingGroupService _workingGroupService;

        public WorkingGroupsController(IWorkingGroupService workingGroupService)
        {
            _workingGroupService = workingGroupService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var data = await _workingGroupService.GetAllAsync();
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("department/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDepartmentAll(long id)
        {
            var data = await _workingGroupService.GetDepartmentAllAsync(id);
            if(data == null) { return NotFound(); }
            return Ok(data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGroup(long id)
        {
            var data = await _workingGroupService.GetGroupAsync(id);
            if(data is null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkingGroup group)
        {
            var result =await _workingGroupService.CreateGroupAsync(group);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, WorkingGroup group)
        {
            var result =await _workingGroupService.UpdateGroupAsync(id, group);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result =await _workingGroupService.DeleteGroupAsync(id);
            return Ok(result);
        }
    }
}
