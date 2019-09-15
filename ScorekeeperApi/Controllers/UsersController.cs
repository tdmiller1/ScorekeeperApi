using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ScorekeeperApi.Models;
using ScorekeeperApi.Services;

namespace ScorekeeperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _Userservice;

        public UsersController(UserService Userservice)
        {
            _Userservice = Userservice;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _Userservice.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var User = _Userservice.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        [HttpPost]
        public ActionResult<User> Create(User User)
        {
            _Userservice.Create(User);

            return CreatedAtRoute("GetUser", new { id = User.Id.ToString() }, User);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User UserIn)
        {
            var User = _Userservice.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            _Userservice.Update(id, UserIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var User = _Userservice.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            _Userservice.Remove(User.Id);

            return NoContent();
        }
    }
}