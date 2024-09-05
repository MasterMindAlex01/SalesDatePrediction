﻿using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Requests;

namespace SalesDatePrediction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumersController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;
        
        [HttpGet("GetSaleDatePredictionList")]
        public async Task<ActionResult> GetSaleDatePredictionPagedListAsync(
            [FromQuery] CustomerQueryFilterRequest filterRequest)
        {
            var result = await _customerService.GetSaleDatePredictionPagedListAsync(filterRequest);
            return Ok(result);
        }
    }
}
