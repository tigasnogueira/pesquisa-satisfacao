// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using AppDesafio.Helpers;
using AppDesafio.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pesquisa.IdentityApi.UoW;
using Pesquisa.SurveyApi.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDesafio.Controllers;

[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISurveyUnitOfWork _surveyUnitOfWork;
    private readonly ILogger _logger;
    private readonly IEmailSender _emailSender;


    public CustomerController(IMapper mapper, IUnitOfWork unitOfWork, ISurveyUnitOfWork surveyUnitOfWork, ILogger<CustomerController> logger, IEmailSender emailSender)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _surveyUnitOfWork = surveyUnitOfWork;
        _logger = logger;
        _emailSender = emailSender;
    }



    // GET: api/values
    [HttpGet]
    public IActionResult Get()
    {
        var allCustomers = _surveyUnitOfWork.Customers.GetCustomers();
        return Ok(_mapper.Map<IEnumerable<CustomerViewModel>>(allCustomers));
    }



    [HttpGet("throw")]
    public IEnumerable<CustomerViewModel> Throw()
    {
        throw new InvalidOperationException("This is a test exception: " + DateTime.Now);
    }



    [HttpGet("email")]
    public async Task<string> Email()
    {
        string recepientName = "QickApp Tester"; //         <===== Put the recepient's name here
        string recepientEmail = "test@ebenmonney.com"; //   <===== Put the recepient's email here

        string message = EmailTemplates.GetTestEmail(recepientName, DateTime.UtcNow);

        (bool success, string errorMsg) = await _emailSender.SendEmailAsync(recepientName, recepientEmail, "Test Email from AppDesafio", message);

        if (success)
            return "Success";

        return "Error: " + errorMsg;
    }



    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value: " + id;
    }



    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }



    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }



    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
