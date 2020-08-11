using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.Business.Models;
using Coworking.Api.DataAccess.Contracts.Repositories;
using Coworking.Api.DataAccess.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Services
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Admin> Get(int id)
        {
            var entidad = await _adminRepository.Get(id);
            return AdminMapper.Map(entidad);
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            var admins = await _adminRepository.GetAll();
            return admins.Select(AdminMapper.Map);
        }

        public async Task<Admin> AddAdmin(Admin admin)
        {
            var addedEntity = await _adminRepository.Add(AdminMapper.Map(admin));
            return AdminMapper.Map(addedEntity);
        }

        public async Task<Admin> UpdateAdmin(Admin admin)
        {
            var updatedEntity = await _adminRepository.Update(AdminMapper.Map(admin));
            return AdminMapper.Map(updatedEntity);
        }

        public async Task DeleteAdmin(int id)
        {
            await _adminRepository.DeleteAsync(id);
        }
    }
}
