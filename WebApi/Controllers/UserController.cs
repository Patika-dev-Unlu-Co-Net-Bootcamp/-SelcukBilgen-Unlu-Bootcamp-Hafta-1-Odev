using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> UserList = new()
        {
            new User
            {
                Id = 1,
                Email = "mahmut.tuncer@mail.com",
                UserName = "Mahmut Tuncer",
                UserRole = UserRole.Specialist
            },
            new User
            {
                Id = 2,
                Email = "nihat.dogan@mail.com",
                UserName = "Nihat Doğan",
                UserRole = UserRole.Specialist
            },
            new User
            {
                Id = 3,
                Email = "ismail.turut@mail.com",
                UserName = "İsmail Türüt",
                UserRole = UserRole.Specialist
            },
            new User
            {
                Id = 4,
                Email = "selcuk.bilgen@mail.com",
                UserName = "Selçuk Bilgen",
                UserRole = UserRole.Client
            },
            new User
            {
                Id = 5,
                Email = "hakki.bulut@mail.com",
                UserName = "Hakkı Bulut",
                UserRole = UserRole.Client
            },
            new User
            {
                Id = 6,
                Email = "serkan.merkan@mail.com",
                UserName = "Serkan Merkan",
                UserRole = UserRole.Client
            }
        };

        [HttpGet]
        public ActionResult<List<User>> GetBooks()
        {
            var userList = UserList.OrderBy(x => x.Id).ToList();
            return Ok(userList);
        }

        // FromRoute
        [HttpGet("{id}")]
        public ActionResult<User> GetById([FromRoute] int id)
        {
            var user = UserList.SingleOrDefault(b => b.Id == id);
            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User newUser)
        {
            var user = UserList.SingleOrDefault(u => u.Email == newUser.Email);

            if (user is not null)
                return BadRequest("Kullanıcı daha önce kayıt olmuş");

            UserList.Add(newUser);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = UserList.SingleOrDefault(u => u.Id == id);
            if (user is null)
                return BadRequest("Kullanıcı bulunamadı");

            user.Email = updatedUser.Email != default ? updatedUser.Email : user.Email;
            user.UserName = updatedUser.UserName != default ? updatedUser.UserName : user.UserName;
            user.UserRole = updatedUser.UserRole != default ? updatedUser.UserRole : user.UserRole;

            return Ok();
        }

        // From Query
        [HttpDelete]
        public IActionResult DeleteUser([FromQuery] int id)
        {
            var user = UserList.SingleOrDefault(u => u.Id == id);
            if (user is null)
                return BadRequest();

            UserList.Remove(user);
            return Ok();
        }


        /*
         * PATCH /api/Persons
         [     
            {       
                "op": "replace",       
                "path": "/email",       
                "value": "email@email.com"  
            } 
         ]
         */

        /*
        [HttpPatch("{id}")]
        public IActionResult UpdateUserEmail(int id, [FromBody] JsonPatchDocument<User> patchDocument)
        {
            var user = UserList.SingleOrDefault(u => u.Id == id);
            if (user is null)
                return BadRequest();

            patchDocument.ApplyTo(user, ModelState);
            if (ModelState.IsValid)
                return Ok(user);

            return BadRequest(ModelState);
        }*/

        [HttpPatch("{id}")]
        public IActionResult UpdateUserEmail(int id, [FromBody] string email)
        {
            var user = UserList.SingleOrDefault(u => u.Id == id);
            if (user is null)
                return BadRequest();

            user.Email = email != default ? email : user.Email;

            return Ok();
        }
        
        
        // Örn: /api/products/list?name=abc

        [HttpGet("list")]
        public ActionResult<List<User>> GetByFilter([FromQuery] string filter)
        {
            var searchedUserList = UserList.FindAll(u => u.UserName.Contains(filter));


            return Ok(searchedUserList);
        }
    }
}