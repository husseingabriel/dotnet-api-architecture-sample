using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coworking.Api.Application.Configuration;
using Coworking.Api.Application.Contracts.ApiCaller;
using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.Business.Models;
using Coworking.Api.Mappers;
using Coworking.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Coworking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IAppConfig _config;
        private readonly IConfiguration _conf;
        private readonly IApiCaller _apiCaller;

        public AdminController(IAdminService adminService, IAppConfig appConfig, IConfiguration conf, IApiCaller apiCaller)
        {
            _adminService = adminService;
            _config = appConfig;
            _conf = conf;
            _apiCaller = apiCaller;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
   
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(AdminModel))]
        public async Task<ActionResult> Get(int id)
        {
            var response = _apiCaller.GetServiceResponseById<Admin>("admin",1);
            var admin = await _adminService.Get(id);
            return Ok(admin);
        }

        /// <summary>
        /// Get all admins
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(List<AdminModel>))]
        public async Task<ActionResult> GetAll()
        {
            var admins = await _adminService.GetAll();
            return Ok(admins);
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
            var result = await _adminService.AddAdmin(AdminMapper.Map(admin));
            return Ok(result);
        }

        /// <summary>
        /// Update an Admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json", Type = typeof(AdminModel))]
        [HttpPut]
        public async Task<ActionResult> UpdateAdmin([FromBody] AdminModel admin)
        {
            var result = await _adminService.UpdateAdmin(AdminMapper.Map(admin));
            return Ok(result);
        }

        /// <summary>
        /// Delete Admin by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(bool))]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmin(int id)
        {
            await _adminService.DeleteAdmin(id);
            return Ok();
        }
    }
}
