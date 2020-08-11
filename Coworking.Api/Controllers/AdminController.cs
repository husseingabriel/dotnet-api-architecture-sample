using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.Mappers;
using Coworking.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coworking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var name = await _adminService.GetAdminName(id);
            return Ok(name);
        }

        /// <summary>
        /// Add a new Admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json",Type=typeof(AdminModel))]
        [HttpPost]
        public async Task<ActionResult> AddAdmin([FromBody]AdminModel admin)
        {
            var name = await _adminService.AddAdmin(AdminMapper.Map(admin));
            return Ok(name);
        }
    }
}
