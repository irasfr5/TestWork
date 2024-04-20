using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YourApp.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;


namespase User.WebApi.Controllers
{
    
    public class UserController : BaseController
    {
        var headers = Request.Headers;
        var form = Request.Form;
        var query = Request.Query;
        var cookies = Request.Cookies;

        private readonly IUserRepository _userRepository;

        [CacheAuthorization] 
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            headers = Request.Headers; 
            form = Request.Form;
            query = Request.Query;
            cookies = Request.Cookies;
            
            var users = _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            headers = Request.Headers; 
            form = Request.Form;
            query = Request.Query;
            cookies = Request.Cookies;

            _userRepository.CreateUser(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>>  Get () //получение данных с сервера
        {
            var query = new userRepository;
            {
                UserId = UserId
            }
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        public void Post ()  // отправка на сервер
        {
            global::System.Object value = users.Add(user);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Delete () //удаление данных с сервера 
        {

        }

    }

}