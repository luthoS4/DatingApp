using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
      public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
    }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<memberDto>>> GetUsers() { // IEnumerable provides a pre written list type
            var users = await _userRepository.GetMembersAsync();

            return Ok(users);
        }



        [HttpGet("{username}")]
        public async Task<ActionResult<memberDto>> GetUser(string username) { // IEnumerable provides a pre written list type
           
            return  await _userRepository.GetMemberAsync(username);
        }
    }
}