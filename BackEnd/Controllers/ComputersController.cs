using ComputerManage.Interfaces;
using ComputerManage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace ComputerManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles="SuperAdministrator,Administrator")]
    public class ComputersController : ControllerBase
    {
        private readonly IComputerService _computerService;
        private List<Computer> _computers = new List<Computer>();

        public ComputersController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var data = await _computerService.GetAllAsync();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("department/{id}")]
        [AllowAnonymous]

        public async Task<IActionResult> GetDepartmentAll(long id)
        {
            var data = await _computerService.GetDepartmentAllAsync(id);
            if (data is null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetComputer(long id)
        {
            var data = await _computerService.GetComputerAsync(id);
            if (data is null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Computer computer)
        {
            var result = await _computerService.CreateComputerAsync(computer);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Computer computer)
        {
            var result = await _computerService.UpdateComputerAsync(id, computer);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _computerService.DeleteComputerAsync(id);
            return Ok(result);
        }
    }
}
