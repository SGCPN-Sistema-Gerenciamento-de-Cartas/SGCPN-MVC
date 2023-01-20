using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGCPN.Authorization;
using SGCPN.Models;
using SGCPN.Services;
using Shared;

namespace SGCPN.Controllers
{
    public class UserController : Controller
    {
        private IUtils _utils;
        private IUserService _userService;

        public UserController(IUtils utils, IUserService userService)
        {
           _utils = utils;
           _userService = userService;
        }

        public async Task<IActionResult> NewUser([FromBody] UsersDetail user)
        {

            if (user == null)
                return StatusCode(StatusCodes.Status400BadRequest, "Blank or null parameters!");

            bool response = await _userService.NewUserAsync(user);

            if (!response)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Problem in inclusion!");
            }

            return StatusCode(StatusCodes.Status201Created, "Menu Added Successfully!");
        }
    }
}
