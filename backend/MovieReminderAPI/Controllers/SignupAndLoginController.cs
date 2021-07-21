using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using SignupAndLoginDLL.Model;
using Model;
using System.Linq;

namespace MovieReminderAPI.Controllers
{
    [ApiController]
    [Route("signuplogin")]
    public class SignupAndLoginController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly UsersModel _usersModel;

        public SignupAndLoginController(MovieContext context)
        {
            _context = context;
        }

        // GET /signuplogin
        [HttpGet]
        public ActionResult<IEnumerable<UsersModel>> GetUsers()
        {
            var items = _context.UsersModels.ToList();
            return items;
        }

        // GET /signuplogin/id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<UsersModel>> GetUserById(int id)
        {
            if (id.ToString() == null)
            {
                return BadRequest();
            }
            var items = _context.UsersModels.Where(item => item.ID == id).ToList();
            return items;
        }

        // POST

        // From Query 
        // /signuplogin?name=""&username=""&email=""&password=""&age=&birthdate=""
        [HttpPost("postquery")]
        public ActionResult<UsersModel> SignupUsersQuery([FromQuery] UsersModel usersModel)
        {
            try
            {
                if (usersModel != null)
                {
                    var uModel = new UsersModel
                    {
                        Name = usersModel.Name,
                        Username = usersModel.Username,
                        Email = usersModel.Email,
                        Password = usersModel.Password,
                        Age = usersModel.Age,
                        BirthDate = usersModel.BirthDate,
                    };
                    _context.UsersModels.Add(uModel);
                    _context.SaveChanges();

                    // return Ok();
                    return CreatedAtAction(nameof(GetUserById), new { id = uModel.ID }, usersModel);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // From Json
        // /signuplogin {"name":"", etc}
        [HttpPost]
        public ActionResult<UsersModel> SignupUsers(UsersModel usersModel)
        {
            try
            {
                if (usersModel != null)
                {
                    var uModel = new UsersModel
                    {
                        Name = usersModel.Name,
                        Username = usersModel.Username,
                        Email = usersModel.Email,
                        Password = usersModel.Password,
                        Age = usersModel.Age,
                        BirthDate = usersModel.BirthDate,
                    };
                    _context.UsersModels.Add(uModel);
                    _context.SaveChanges();

                    // return Ok();
                    return CreatedAtAction(nameof(GetUserById), new { id = uModel.ID }, usersModel);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        // ---------------------------------------------------

        // From Json Body
        // PUT changeuser/{id}
        [HttpPut("changeuser/{id}")]
        public ActionResult<UsersModel> ChangeUser(int id, UsersModel userModel)
        {
            try
            {
                if (id.ToString() != null)
                {
                    var user = _context.UsersModels.Where(userID => userID.ID == id)
                    .FirstOrDefault<UsersModel>();

                    if (_context.UsersModels != null)
                    {
                        user.Name = userModel.Name;
                        user.Username = userModel.Username;
                        user.Email = userModel.Email;
                        user.Password = userModel.Password;
                        user.Age = userModel.Age;
                        user.BirthDate = userModel.BirthDate;

                        _context.SaveChanges();
                        return Ok(user.ID);
                    }
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE /delete/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult<UsersModel> DeleteUser(int id)
        {
            try
            {
                if (id.ToString() == null)
                {
                    return BadRequest();
                }
                var delete = _context.UsersModels.First(x => x.ID == id);
                _context.Remove(delete);
                _context.SaveChanges();
                return Ok(nameof(GetUsers));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}