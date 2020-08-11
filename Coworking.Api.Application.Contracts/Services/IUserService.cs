using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Contracts.Services
{
    public interface IUserService
    {
        Task GetUserName(int idUser, int idAdmin);
    }
}
