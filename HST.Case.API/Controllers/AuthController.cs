﻿using Business.Features.Auth.Commands.Login;
using Business.Features.Auth.Commands.Register;
using Core.Entities.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HST.Case.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
     

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var result = await Mediator.Send(new LoginCommand
            {
                UserForLoginDto = userForLoginDto
            });
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
        {
            var result = await Mediator.Send(new RegisterForAdminCommand
            {
                CreateUserDto = createUserDto
            });

            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result.Error);
        }
    }
}
