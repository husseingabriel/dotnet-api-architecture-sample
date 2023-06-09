﻿using Coworking.Api.Application.Configuration;
using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.Business.Models;
using Coworking.Api.DataAccess.Contracts.Repositories;
using Coworking.Api.DataAccess.Mappers;
using Polly;
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
        private readonly IAppConfig _appConfig;

        public AdminService(IAdminRepository adminRepository, IAppConfig appConfig)
        {
            _adminRepository = adminRepository;
            _appConfig = appConfig;
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

            var maxTrys = _appConfig.MaxTrys;
            var timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait);

            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(maxTrys, i=> timeToWait);
            return await retryPolity.ExecuteAsync(async () =>
            {
                var addedEntity = await _adminRepository.Add(AdminMapper.Map(admin));
                return AdminMapper.Map(addedEntity);
            });
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
