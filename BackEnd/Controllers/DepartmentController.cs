﻿using ComputerManage.Interfaces;
using ComputerManage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _departmentService.GetAllAsync();
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(long id)
        {
            var data = await _departmentService.GetDepartmentAsync(id);
            if(data is null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            var result =await _departmentService.CreateDepartmentAsync(department);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Department department)
        {
            var result =await _departmentService.UpdateDepartmentAsync(id, department);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result =await _departmentService.DeleteDepartmentAsync(id);
            return Ok(result);
        }
    }
}
