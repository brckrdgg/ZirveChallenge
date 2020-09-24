using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZirveChallenge.API.Dto;
using ZirveChallenge.API.Filters;
using ZirveChallenge.Core.Dto;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Core.Helpers;
using ZirveChallenge.Core.Services;

namespace ZirveChallenge.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
           
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return Ok(_mapper.Map<UserDto>(user));
        }

        /// <summary>
        /// Kullanıcı Ekleme
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {         
            var newUser = await _userService.UserAdd(_mapper.Map<User>(userDto));
            return Created(string.Empty, _mapper.Map<UserDto>(newUser));
        }

        [HttpPut]
        public IActionResult Update(UserDto userDto)
        {

            var user = _userService.Update(_mapper.Map<User>(userDto));
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetByIdAsync(id).Result;
            _userService.Remove(user);
            return NoContent();
        }



        /// <summary>
        /// Login Olma
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>

        [ValidationFilter]
        [HttpPost]      
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userService.Login(loginDto);
            return Ok(user);
        }



        /// <summary>
        /// Kullanıcı Ekleme
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        /// 
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> UserAdd(UserDto userDto)
        {

            var newUser = await _userService.UserAdd(_mapper.Map<User>(userDto));
            return Created(string.Empty, _mapper.Map<UserDto>(newUser));
        }

    }
}
