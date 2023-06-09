﻿using Coworking.Api.Business.Models;
using Coworking.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.Mappers
{
    public static class AdminMapper
    {
        public static Admin Map(AdminModel model)
        {
            return new Admin()
            {
                Id = model.Id,
                Email = model.Email,
                HiredDate = DateTime.Now,
                Name = model.Name,
                Phone = model.Phone
            };
        }
    }
}
