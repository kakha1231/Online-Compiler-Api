﻿using informaticsge.Dto;
using informaticsge.models;
using informaticsge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace informaticsge.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private UserManager<User> _userManager;
    private UserService _userService;
    
    public UserController(UserManager<User> userManager, UserService userService)
    {
        _userManager = userManager;
        _userService = userService;
    }

    [HttpGet("/hello")]
    [Authorize]
    public async Task<User> hello()
    {
        
        var userid = User.Claims.First(User => User.Type == "Email");
        var test = userid.Value;
        var user = await _userManager.FindByEmailAsync(test);
        Console.WriteLine(test);
        return user;
    }
    
    [HttpGet("/myaccount")]
    [Authorize]
    public async Task<MyAccountDTO> MyAccount()
    {
        var userid = User.Claims.First(User => User.Type == "Id").Value;
        var user = await _userService.MyAccount(userid);
        return  user;
    }

    [HttpGet("/mysolutions")]
    [Authorize]
    public async Task<IActionResult> MySolutions()
    {
        try
        {
            var userid = User.Claims.First(User => User.Type == "Id").Value;
            var solutions = await _userService.MySolutions(userid);

            return Ok(solutions);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}