using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IAdminService _adminService;
        private readonly IUserRepository _userRepository;
        public UserService(IAdminService adminService, IUserRepository userRepository)
        {
            _adminService = adminService;
            _userRepository = userRepository;
        }

        public async Task GetUserName(int idUser, int idAdmin)
        {
            //user
            var user = await _userRepository.Get(idUser);

            //await _adminService.GetAdminName(idAdmin);
        }
    }

}
