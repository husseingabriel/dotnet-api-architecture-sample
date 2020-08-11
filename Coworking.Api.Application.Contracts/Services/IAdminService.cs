
using Coworking.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Contracts.Services
{
    public interface IAdminService
    {
        Task<Admin> Get(int id);
        Task<IEnumerable<Admin>> GetAll();
        Task<Admin> AddAdmin(Admin admin);
        Task<Admin> UpdateAdmin(Admin admin);
        Task DeleteAdmin(int id);
    }
}
