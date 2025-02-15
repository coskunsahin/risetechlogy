﻿using fakestoreapi.application.Common.Interfaces;

using fakestoreapi.application.Queries;
using fakestoreapi.application.ViewModels;
using RabbitMQ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using fakestoreapi.api.Services;
using fakestoreapi.rabbit;


namespace fakestoreapi.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;


        private long lon;
        public SistemController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;

        }

        [HttpGet("{lon}")]
        public async Task<IActionResult> GetById(long lon)
        {
            return Ok(await Mediator.Send(new GetSistemQuery { lon = lon }));
        }

        [HttpGet]

        
        public async Task<IActionResult> About()
        {
            return Ok(await Mediator.Send(new Ping ()));
        }

       
        [HttpGet("GetStaticlist")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetStaticlist()
        {
            return Ok(await Mediator.Send(new GetStaticList()));
        }

    }
}
