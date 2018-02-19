﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ivforumWebAPI.Data;
using ivforumWebAPI.Models;
using ivforumWebAPI.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ivforumWebAPI.Controllers
{
    [EnableCors("all")]
    [Route("api/accounts")]
    public class AccountsController : Controller
    {
        private readonly DbHandler db;
        private readonly UserManager<UserModel> userManager;

        public AccountsController(UserManager<UserModel> _userManager, DbHandler _db)
        {
            db = _db;
            userManager = _userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserModel userModel = new UserModel
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Email
            };

            User user = new User
            {
                Id = Guid.NewGuid(),
                Identity = userModel
            };

            var result = await userManager.CreateAsync(userModel, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult("NOPE");

            await db.DbUsers.AddAsync(user);
            await db.SaveChangesAsync();

            return new JsonResult("200 OK: Account created");
        }
    }
}